using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Pokemons.Battle
{
    class PokemonBattleSpriteData
    {
        public string TextureName { get; set; }
        public Color Color { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle DrawRectangle => new Rectangle((int) Position.X, (int) Position.Y, Width, Height);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public PokemonBattleSpriteData(int width, int height, Vector2 position, Color color, string textureName)
        {
            Color = color;
            TextureName = textureName;
            Width = width;
            Height = height;
            Position = position;
        }
    }
}
