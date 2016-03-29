namespace LetsCreatePokemon.World.Tiles
{
    class TileCollision : Tile, ICollisionObject
    {
        public bool Collide(int xTilePosition, int yTilePosition)
        {
            return xTilePosition == XTilePosition && yTilePosition == YTilePosition;
        }
    }
}
