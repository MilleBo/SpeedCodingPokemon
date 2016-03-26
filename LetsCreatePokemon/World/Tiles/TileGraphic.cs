using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Tiles
{
    public class TileGraphic : Tile
    {
        private const int TextureWidth = 16;
        private const int TextureHeight = 16;
        private Texture2D texture;
        private int animationIndex;
        private double counter; 

        public int ZTilePosition { get; set; }
        public string TextureName { get; set; }
        public List<TileFrame> TileFrames { get; set; }
        public float AnimationSpeed { get; set; }

        public TileGraphic()
        {
            TileFrames = new List<TileFrame>();
            animationIndex = 0; 
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture(TextureName); 
        }

        public void Update(double gameTime)
        {
            if (TileFrames.Count <= 1)
                return;
            counter += gameTime;
            if (counter > AnimationSpeed)
            {
                counter = 0;
                animationIndex++;
                if (animationIndex > TileFrames.Count - 1)
                    animationIndex = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(XTilePosition*Width, YTilePosition*Height, Width, Height), 
                new Rectangle(TileFrames[animationIndex].TextureXPosition, TileFrames[animationIndex].TextureYPosition, TextureWidth, TextureHeight),
                Color.White);
        }
    }
}
