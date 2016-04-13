using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.Windows.Message
{
    internal class MessagePage
    {
        private const int CharacterDelay = 200; 
        private readonly SpriteFont font;
        private readonly string fullText;
        private readonly Vector2 position;
        private int index;
        private double counter;

        public bool IsDone { get; set; }

        public MessagePage(string text, Vector2 position, SpriteFont font)
        {
            this.fullText = text;
            this.position = position;
            this.font = font;
            index = 0;
            counter = 0;
        }

        public void Update(double gameTime)
        {
            if (index >= fullText.Length)
                return;
            counter += gameTime;
            if (counter > CharacterDelay)
            {
                counter = 0;
                index++;
                if (index == fullText.Length - 1)
                    IsDone = true;
            }
        }

        public void SpeedUpText()
        {
            index = fullText.Length;
            IsDone = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, fullText.Substring(0, index), position, Color.Gray);
        }
    }
}
