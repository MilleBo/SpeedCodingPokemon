using System.Collections.Generic;
using LetsCreatePokemon.Services.World.EventSwitches;
using LetsCreatePokemon.World;

namespace LetsCreatePokemon.Services.World
{
    internal interface IEntityLoader
    {
        IList<WorldObject> LoadEntities(string mapName, IWorldData worldData, IEventRunner eventRunner, EventSwitchHandler eventSwitchHandler);
    }
}