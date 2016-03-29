namespace LetsCreatePokemon.World
{
    interface ICollisionObject
    {
        bool Collide(int xTilePosition, int yTilePosition);
    }
}
