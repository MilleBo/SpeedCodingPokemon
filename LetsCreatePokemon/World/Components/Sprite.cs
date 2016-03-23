using LetsCreatePokemon.Data;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.World.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Components
{
    internal class Sprite : Component
    {
        private readonly SpriteData spriteData;
        private Texture2D texture;
        public Rectangle DrawFrame { get; set; }
        public Vector2 PositionOffset { get; private set; }
        public Vector2 TilePosition => new Vector2(spriteData.XTilePosition, spriteData.YTilePosition);
        public Vector2 CurrentPosition => new Vector2(spriteData.XTilePosition*Tile.Width + PositionOffset.X, spriteData.YTilePosition*Tile.Height + PositionOffset.Y);

        public Sprite(IComponentOwner owner, SpriteData spriteData) : base(owner)
        {
            this.spriteData = spriteData;
            PositionOffset = new Vector2(0, 0);
            DrawFrame = new Rectangle(0, 0, spriteData.Width, spriteData.Height);
        }

        public Sprite(IComponentOwner owner, SpriteData spriteData, Rectangle drawFrame) : this(owner, spriteData)
        {
            DrawFrame = drawFrame;
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture(spriteData.TextureName);
            base.LoadContent(contentLoader);
        }

        public override void Update(double gameTime)
        {  

        }

        public void IncreasePositionOffset(float x, float y)
        {
            PositionOffset = new Vector2(PositionOffset.X + x, PositionOffset.Y + y);
        }

        public void ResetPositionOffset()
        {
            PositionOffset = new Vector2(0, 0);
        }

        public void UpdateTilePosition(int x, int y)
        {
            spriteData.XTilePosition = x;
            spriteData.YTilePosition = y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)CurrentPosition.X, (int)CurrentPosition.Y, spriteData.Width, spriteData.Height), DrawFrame, spriteData.Color);
        }
    }
}
