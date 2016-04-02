using System.Collections.Generic;
using LetsCreatePokemon.World;

namespace LetsCreatePokemon.Services.World
{
    internal interface IEntityLoader
    {
        IList<WorldObject> LoadEntities(string mapName, IWorldData worldData, IEventRunner eventRunner);
    }
}