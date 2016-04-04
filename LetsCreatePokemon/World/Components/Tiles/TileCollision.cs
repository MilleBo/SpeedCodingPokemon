using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Components.Tiles
{
    internal class TileCollision : Tile, ICollisionComponent
    {
        public TileCollision(IComponentOwner owner, int xTilePosition, int yTilePosition) : base(owner, xTilePosition, yTilePosition)
        {
        }

        public bool Collide(int xTilePosition, int yTilePosition)
        {
            return xTilePosition == XTilePosition && yTilePosition == YTilePosition;
        }

        public bool Collide(Vector2 position)
        {
            return Collide((int)position.X, (int)position.Y);
        }

    }
}
