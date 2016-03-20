using System;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Components
{
    class TestComponent : Component
    {
        private readonly Input input;
        private Vector2 position; 
        private Texture2D texture; 

        public TestComponent(IComponentOwner owner) : base(owner)
        {
            this.input = new InputKeyboard();
            this.input.NewInput += OnNewInput;
            position = new Vector2(100, 100);
        }

        private void OnNewInput(object sender, EventArg.NewInputEventArgs e)
        {
            switch (e.Inputs)
            {
                case Common.Inputs.Left:
                    position.X--;
                    break;
                case Common.Inputs.Up:
                    position.Y--;
                    break;
                case Common.Inputs.Right:
                    position.X++;
                    break;
                case Common.Inputs.Down:
                    position.Y++;
                    break;
                case Common.Inputs.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture("NPC/main_character_single");
        }

        public override void Update(double gameTime)
        {
            input.Update(gameTime);  
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 42, 57), Color.White);
        }
    }
}
