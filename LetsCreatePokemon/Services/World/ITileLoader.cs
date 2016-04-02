using System.Collections.Generic;
using LetsCreatePokemon.World;

namespace LetsCreatePokemon.Services.World
{
    internal interface ITileLoader
    {
        IList<WorldObject> LoadTiles(string mapName);
    }
}