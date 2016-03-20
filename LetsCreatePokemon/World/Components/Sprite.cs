using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Data;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Components
{
    internal class Sprite : Component
    {
        private readonly SpriteData spriteData;
        private Texture2D texture;
        public Rectangle DrawFrame { get; set; }

        public Sprite(IComponentOwner owner, SpriteData spriteData) : base(owner)
        {
            this.spriteData = spriteData;
            DrawFrame = new Rectangle(0, 0, spriteData.Width, spriteData.Height);
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture(spriteData.TextureName);
            base.LoadContent(contentLoader);
        }

        public override void Update(double gameTime)
        {  

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           //32 will later change to a constant in the tile class.
           spriteBatch.Draw(texture, new Rectangle(spriteData.XTilePosition*32, spriteData.YTilePosition*32, spriteData.Width, spriteData.Height), DrawFrame, spriteData.Color);
        }
    }
}
