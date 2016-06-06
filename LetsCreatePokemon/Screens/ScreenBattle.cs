using LetsCreatePokemon.Battle;
using LetsCreatePokemon.Battle.Phases;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Screens;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Screens
{
    internal class ScreenBattle : Screen
    {
        private IContentLoader contentLoader;
        private readonly IWindowQueuer windowQueuer;
        private IPhase currentPhase;
        private readonly BattleData battleData;
        private readonly WindowBattle windowBattle;
        private Texture2D backgroundTexture; 

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ScreenBattle(IScreenLoader screenLoader, IWindowQueuer windowQueuer, IPhase startPhase, BattleData battleData) : base(screenLoader)
        {
            this.windowQueuer = windowQueuer;
            this.battleData = battleData;
            currentPhase = startPhase;
            windowBattle = new WindowBattle(new Vector2(0, 113), 240, 45);
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            backgroundTexture = contentLoader.LoadTexture("Battle/Backgrounds/background");
            windowBattle.LoadContent(contentLoader);
            currentPhase.LoadContent(contentLoader, windowQueuer, battleData);
            this.contentLoader = contentLoader;
        }

        public override void Update(double gameTime)
        {
            currentPhase.Update(gameTime);
            if (currentPhase.IsDone)
            {
                currentPhase = currentPhase.GetNextPhase();
                currentPhase.LoadContent(contentLoader, windowQueuer, battleData);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0), Color.White);
            currentPhase.Draw(spriteBatch);
            windowBattle.Draw(spriteBatch);
        }
    }
}
