using System.Collections.Generic;
using LetsCreatePokemon.World.Tiles;

namespace LetsCreatePokemon.Services.World
{
    internal interface ITileLoader
    {
        IList<TileGraphic> LoadGraphicTiles(string mapName);
    }
}