using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreatePokemon.World.Tiles
{
    public abstract class Tile
    {
        public const int Width = 16;
        public const int Height = 16;
        
        public int XTilePosition { get; set; }
        public int YTilePosition { get; set; } 
    }
}
