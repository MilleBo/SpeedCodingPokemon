using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using LetsCreatePokemon.EventArg;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.Windows.Message
{
    class WindowMessage : Window
    {
        private const int MaxNumberOfRows = 2; 
        private readonly string text;
        private readonly Input input;
        private Vector2 margin;
        private List<MessagePage> pages;
        private int pageIndex;
        private MessageArrow messageArrow;

        public WindowMessage(Vector2 position, int width, int height, string text, Input input) : base(position, width, height)
        {
            this.text = text;
            this.input = input;
            this.input.NewInput += InputOnNewInput;
            this.input.ThrottleInput = true; 
            pages = new List<MessagePage>();
            pageIndex = 0; 
            margin = new Vector2(10);
            messageArrow = new MessageArrow(position + new Vector2(width - margin.X*1.6f, height - margin.Y*1.6f));
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (newInputEventArgs.Inputs == Common.Inputs.A)
            {
                if (pages[pageIndex].IsDone)
                {
                    pageIndex++;
                    if (pageIndex >= pages.Count)
                    {
                        IsDone = true;
                        input.NewInput -= InputOnNewInput;
                    }
                }
                else
                {
                    pages[pageIndex].SpeedUpText(); 
                }
            }
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            base.LoadContent(contentLoader);
            CreatePages(contentLoader.LoadFont("PokemonFont"));
            messageArrow.LoadContent(contentLoader);
        }

        private void CreatePages(SpriteFont font)
        {
            var words = text.Split(' '); 
            var rowText = new StringBuilder();
            var index = 0;
            var rowIndex = 0;
            while (index < words.Length)
            {
                var word = words[index];
                var oldRowLength = rowText.Length;
                rowText.Append($"{word} ");
                if (font.MeasureString(rowText).X > Width - margin.X)
                {
                    rowText.Remove(oldRowLength, rowText.Length - oldRowLength);
                    if (rowIndex == MaxNumberOfRows - 1)
                    {
                        pages.Add(new MessagePage(rowText.ToString(), Position + margin, font));
                        rowText.Clear();
                        rowIndex = 0;
                    }
                    else
                    {
                        rowText.Append($"{Environment.NewLine}{Environment.NewLine}");
                        rowIndex++; 
                    }
                }
                else
                {
                    index++;
                }
            }
            if (rowText.Length > 0)
            {
                pages.Add(new MessagePage(rowText.ToString(), Position + margin, font));
            }
        }

        public override void Update(double gameTime)
        {
            input.Update(gameTime);
            if (IsDone)
                return;
            messageArrow.Update(gameTime);
            pages[pageIndex].Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsDone)
                return; 
            base.Draw(spriteBatch);
            pages[pageIndex].Draw(spriteBatch);
            if (pages[pageIndex].IsDone && pageIndex < pages.Count - 1)
            {
                messageArrow.Draw(spriteBatch);
            }
        }
    }
}
