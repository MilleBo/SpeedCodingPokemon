using System;
using LetsCreatePokemon.Screens;
using LetsCreatePokemon.Screens.ScreenTransitionEffects;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.Screens
{
    internal class ScreenLoader : IScreenLoader
    {
        private Screen previousScreen;
        private Screen currentScreen;
        private Screen tempScreen;
        private readonly IScreenTransitionEffect previousScreenTransitionEffect;
        private readonly IScreenTransitionEffect newScreenTransitionEffect;
        private readonly IContentLoader contentLoader;
        private enum Phases { ClosingPreviousScreen, SettingUpNewScreen, Running}
        private Phases currentPhase; 

        public ScreenLoader(IScreenTransitionEffect previousScreenTransitionEffect,
            IScreenTransitionEffect newScreenTransitionEffect, IContentLoader contentLoader)
        {
            this.previousScreenTransitionEffect = previousScreenTransitionEffect;
            this.newScreenTransitionEffect = newScreenTransitionEffect;
            this.contentLoader = contentLoader;
            currentPhase = Phases.Running;
        }

        public void LoadContent()
        {
            previousScreenTransitionEffect.LoadContent(contentLoader);
            newScreenTransitionEffect.LoadContent(contentLoader);
        }

        public void Update(double gameTime)
        {
            switch (currentPhase)
            {
                case Phases.ClosingPreviousScreen:
                    previousScreenTransitionEffect.Update(gameTime);
                    if (previousScreenTransitionEffect.IsDone)
                    {
                        PrepareNewScreen();
                    }
                    break;
                case Phases.SettingUpNewScreen:
                    newScreenTransitionEffect.Update(gameTime);
                    if (newScreenTransitionEffect.IsDone)
                    {
                        currentPhase = Phases.Running;
                    }
                    break;
                case Phases.Running:
                    currentScreen?.Update(gameTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void LoadScreen(Screen screen)
        {
            currentPhase = Phases.ClosingPreviousScreen;
            previousScreenTransitionEffect.Start();
            tempScreen = screen;
        }

        public void PrepareNewScreen()
        {
            previousScreen = currentScreen;
            currentScreen = tempScreen;
            currentScreen.LoadContent(contentLoader);
            newScreenTransitionEffect.Start();
            currentPhase = Phases.SettingUpNewScreen;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen?.Draw(spriteBatch);
            previousScreenTransitionEffect.Draw(spriteBatch);
            newScreenTransitionEffect.Draw(spriteBatch);
        }

    }
}
