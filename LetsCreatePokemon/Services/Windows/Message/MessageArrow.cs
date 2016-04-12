using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.Windows.Message
{
    internal class MessageArrow
    {
        private const float Speed = 0.5f;
        private Vector2 position;
        private Texture2D arrowTexture;
        private double counter;
        private bool goingDown;

        public MessageArrow(Vector2 position)
        {
            this.position = position;
            counter = 0;
            goingDown = true; 
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            arrowTexture = contentLoader.LoadTexture("Windows/message_arrow");
        }

        public void Update(double gameTime)
        {
            counter += gameTime;
            if (goingDown)
            {
                position += new Vector2(0, Speed);
            }
            else
            {
                position -= new Vector2(0, Speed);
            }
            if (counter > 200)
            {
                counter = 0;
                goingDown = !goingDown;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(arrowTexture, position, Color.White);
        }
    }

}
