using System;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.TrainerSprites
{
    internal abstract class TrainerSprite
    {
        protected const int TrainerTextureHeight = 64;
        protected const int TrainerTextureWidth = 64;

        protected Rectangle DrawRectangle;
        private Texture2D texture;
        protected Vector2 Position;
        protected Vector2 WantedPosition;
        private readonly string textureName;

        public bool IsDone => Math.Abs(Position.X - WantedPosition.X) < 5;

        protected TrainerSprite(string textureName)
        {
            this.textureName = textureName;
            DrawRectangle = new Rectangle(0, 0, TrainerTextureWidth, TrainerTextureHeight);
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture(textureName);
        }

        public void Update(double gameTime)
        {
            if (IsDone)
                return;
            Move(gameTime);
        }

        protected abstract void Move(double gameTime);

        public abstract void StartMoveOut();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, DrawRectangle, Color.White);
        }
    }
}
