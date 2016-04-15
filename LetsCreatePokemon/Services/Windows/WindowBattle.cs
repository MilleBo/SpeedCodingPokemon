using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Services.Windows
{
    class WindowBattle : Window
    {
        public WindowBattle(Vector2 position, int width, int height) : base(position, width, height)
        {
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            Texture = contentLoader.LoadTexture("Windows/windowBattleFrame");
        }

        public override void Update(double gameTime)
        {
            
        }
    }
}
