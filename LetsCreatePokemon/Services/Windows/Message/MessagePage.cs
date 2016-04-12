using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.Windows.Message
{
    internal class MessagePage
    {
        private const int CharacterDelay = 200; 
        private readonly SpriteFont font;
        private readonly char[] text;
        private readonly Vector2 position;
        private int index;
        private double counter;
        private string currentText;

        public bool IsDone { get; set; }

        public MessagePage(string text, Vector2 position, SpriteFont font)
        {
            this.text = text.ToCharArray();
            this.position = position;
            this.font = font;
            index = 0;
            counter = 0;
            currentText = "";
        }

        public void Update(double gameTime)
        {
            if (index >= text.Length)
                return;
            counter += gameTime;
            if (counter > CharacterDelay)
            {
                counter = 0;
                index++;
                if (index == text.Length - 1)
                    IsDone = true;
                UpdateText();
            }
        }

        private void UpdateText()
        {
            currentText = "";
            for (int n = 0; n < index; n++)
            {
                currentText += text[n];
            }
        }

        public void SpeedUpText()
        {
            index = text.Length;
            UpdateText();
            IsDone = true;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, currentText, position, Color.Gray);
        }
    }
}
