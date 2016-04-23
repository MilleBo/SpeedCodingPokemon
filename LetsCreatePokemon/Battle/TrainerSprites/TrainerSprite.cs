using System;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.TrainerSprites
{
    internal abstract class TrainerSprite
    {
        private Texture2D texture;
        protected Vector2 Position;
        protected Vector2 WantedPosition;
        private readonly string textureName;

        public bool IsDone => Math.Abs(Position.X - WantedPosition.X) < 5;

        protected TrainerSprite(string textureName)
        {
            this.textureName = textureName;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture(textureName);
        }

        public void Update(double gameTime)
        {
            if (IsDone)
                return;
            Move();
        }

        protected abstract void Move();

        public abstract void StartMoveOut();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
