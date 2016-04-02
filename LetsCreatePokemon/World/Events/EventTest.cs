using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Events
{
    internal class EventTest : IEvent
    {
        private Texture2D texture;
        private Vector2 position; 

        public bool IsDone { get; private set; }

        public void Initialize(IWorldData worldData)
        {
            position = new Vector2(-100, 40);
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture("pi_test");
        }

        public void Update(double gameTime)
        {
            position.X++;
            if (position.X > 240)
                IsDone = true; 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 40, 40), Color.White);
        }
    }
}
