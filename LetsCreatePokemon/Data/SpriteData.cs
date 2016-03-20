using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Data
{
    internal class SpriteData
    {
        public int XTilePosition { get; set; }
        public int YTilePosition { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string TextureName { get; set; }
        public Color Color { get; set; }
    }
}
