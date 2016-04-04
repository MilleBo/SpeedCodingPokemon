using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World
{
    interface ICollisionComponent : IComponent
    {
        bool Collide(int xTilePosition, int yTilePosition);
        bool Collide(Vector2 position);
    }
}
