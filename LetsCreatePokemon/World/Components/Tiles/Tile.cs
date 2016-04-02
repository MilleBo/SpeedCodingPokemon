namespace LetsCreatePokemon.World.Components.Tiles
{
    internal abstract class Tile : Component
    {
        public const int Width = 16;
        public const int Height = 16;
        
        public int XTilePosition { get; set; }
        public int YTilePosition { get; set; }

        protected Tile(IComponentOwner owner, int xTilePosition, int yTilePosition) : base(owner)
        {
            XTilePosition = xTilePosition;
            YTilePosition = yTilePosition;
        }
    }
}
