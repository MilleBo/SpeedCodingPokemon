using System.Collections.Generic;
using LetsCreatePokemon.World;

namespace LetsCreatePokemon.Services.World
{
    interface IWorldData
    {
        WorldObject GetWorldObject(string id);
        List<T> GetComponents<T>() where T : IComponent;
    }
}
