using System;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.Windows
{
    internal abstract class Window
    {
        private const int CornerWidth = 7;
        private const int CornerHeight = 7;
        private const int SideWidth = 7;
        private const int SideHeight = 8;
        private const int TopWidth = 8;
        private const int TopHeight = 7;
        private const int MiddleWidth = 6;
        private const int MiddleHeight = 6;

        protected Texture2D Texture;
        protected Vector2 Position;
        protected int Height;
        protected int Width; 
        public bool IsDone { get; protected set; }

        protected Window(Vector2 position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height; 
        }

        public virtual void LoadContent(IContentLoader contentLoader)
        {
            Texture = contentLoader.LoadTexture("Windows/windowframe");
        }

        public abstract void Update(double gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            DrawCorners(spriteBatch);
            DrawSides(spriteBatch);
            DrawTopAndBottom(spriteBatch);
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X + SideWidth, (int)Position.Y + TopHeight, Width - SideWidth * 2, Height - TopHeight * 2), new Rectangle(10, 10, MiddleWidth, MiddleHeight), Color.White);
        }

        private void DrawCorners(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, CornerWidth, CornerHeight), new Rectangle(1, 1, CornerWidth, CornerHeight), Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X + Width - CornerWidth, (int)Position.Y, CornerWidth, CornerHeight), new Rectangle(18, 1, CornerWidth, CornerHeight), Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y + Height - CornerHeight, CornerWidth, CornerHeight), new Rectangle(1, 18, CornerWidth, CornerHeight), Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X + Width - CornerWidth, (int)Position.Y + Height - CornerHeight, CornerWidth, CornerHeight), new Rectangle(18, 18, CornerWidth, CornerHeight), Color.White);
        }

        private void DrawSides(SpriteBatch spriteBatch)
        {
            var sideCount = (double)(Height - CornerHeight * 2) / SideHeight;
            for (int n = 0; n < Math.Floor(sideCount); n++)
            {
                var y = (int)Position.Y + SideHeight * (n + 1) - 1;
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X, y, SideWidth, SideHeight), new Rectangle(1, 9, SideWidth, SideHeight), Color.White);
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X + Width - SideWidth, y, SideWidth, SideHeight), new Rectangle(18, 9, SideWidth, SideHeight), Color.White);
            }
            if (sideCount % 1 != 0)
            {
                var y = (int)(Position.Y + SideHeight * Math.Floor(sideCount));
                var height = (int)Position.Y + Height - CornerHeight - y + 1;
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X, y, SideWidth, height), new Rectangle(1, 9, SideWidth, SideHeight), Color.White);
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X + Width - SideWidth, y, SideWidth, height), new Rectangle(18, 9, SideWidth, SideHeight), Color.White);
            }
        }

        private void DrawTopAndBottom(SpriteBatch spriteBatch)
        {
            var topCount = (double)(Width - CornerWidth * 2) / TopWidth;
            for (int n = 0; n < Math.Floor(topCount); n++)
            {
                var x = (int)Position.X + TopWidth * (n + 1) - 1;
                spriteBatch.Draw(Texture, new Rectangle(x, (int)Position.Y, TopWidth, TopHeight), new Rectangle(9, 1, TopWidth, TopHeight), Color.White);
                spriteBatch.Draw(Texture, new Rectangle(x, (int)Position.Y + Height - TopHeight, TopWidth, TopHeight), new Rectangle(9, 18, TopWidth, TopHeight), Color.White);
            }
            if (topCount % 1 != 0)
            {
                var x = (int)(Position.X + TopWidth * Math.Floor(topCount));
                var width = (int)Position.X + Width - CornerWidth - x;
                spriteBatch.Draw(Texture, new Rectangle(x, (int)Position.Y, width, TopHeight), new Rectangle(9, 1, TopWidth, TopHeight), Color.White);
                spriteBatch.Draw(Texture, new Rectangle(x, (int)Position.Y + Height - TopHeight, width, TopHeight), new Rectangle(9, 18, TopWidth, TopHeight), Color.White);
            }
        }

    }
}
