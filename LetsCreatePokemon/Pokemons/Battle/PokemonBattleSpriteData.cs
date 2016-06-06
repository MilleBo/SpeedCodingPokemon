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
        public const int TextureWidth = 64;
        public const int TextureHeight = 64;

        public enum PokemonFacings
        {
            Front,
            Back
        };

        public string TextureName { get; set; }
        public Color Color { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle => new Rectangle((int) Position.X, (int) Position.Y, Width, Height);
        public Rectangle DrawRectangle => new Rectangle(TextureWidth*(int)PokemonFacing, 0, TextureWidth, TextureHeight);
        public PokemonFacings PokemonFacing { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public PokemonBattleSpriteData(int width, int height, Vector2 position, Color color, string textureName, PokemonFacings pokemonFacing)
        {
            Color = color;
            TextureName = textureName;
            PokemonFacing = pokemonFacing;
            Width = width;
            Height = height;
            Position = position;
        }
    }
}
