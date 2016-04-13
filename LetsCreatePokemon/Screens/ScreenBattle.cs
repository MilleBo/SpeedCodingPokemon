using LetsCreatePokemon.Battle.Phases;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Screens
{
    internal class ScreenBattle : Screen
    {
        private IPhase currentPhase;
        private Texture2D backgroundTexture; 

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ScreenBattle(IScreenLoader screenLoader, IPhase startPhase) : base(screenLoader)
        {
            currentPhase = startPhase;
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            backgroundTexture = contentLoader.LoadTexture("BattleBackgrounds/background");
            currentPhase.LoadContent(contentLoader);
        }

        public override void Update(double gameTime)
        {
            currentPhase.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0), Color.White);
            currentPhase.Draw(spriteBatch);
        }
    }
}
