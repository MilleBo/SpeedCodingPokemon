using System.Collections.Generic;
using LetsCreatePokemon.World;

namespace LetsCreatePokemon.Services.World
{
    internal interface IEntityLoader
    {
        IList<Entity> LoadEntities(string mapName, IList<ICollisionObject> collisionObjects, IEventRunner eventRunner);
    }
}