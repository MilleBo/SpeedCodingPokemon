using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.TrainerSprites
{
    internal abstract class TrainerSprite
    {
        private Texture2D texture;
        protected Vector2 position;
        private readonly string textureName;

        public bool IsDone { get; set; }

        protected TrainerSprite(string textureName)
        {
            this.textureName = textureName;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture(textureName);
        }

        public abstract void Update(double gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
