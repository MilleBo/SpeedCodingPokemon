using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World
{
    internal interface IDrawComponent : IComponent
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
