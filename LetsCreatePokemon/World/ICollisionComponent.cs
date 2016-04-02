namespace LetsCreatePokemon.World
{
    interface ICollisionComponent : IComponent
    {
        bool Collide(int xTilePosition, int yTilePosition);
    }
}
