using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Emotions
{
    internal interface IEmotion
    {
        bool IsDone { get; }
        void PlayEmotion(int xTilePosition, int yTilePosition);
        void LoadContent(IContentLoader contentLoader);
        void Update(double gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
