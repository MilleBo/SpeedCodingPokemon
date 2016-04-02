using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.World;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Events
{
    internal interface IEvent
    {
        bool IsDone { get; }
        void Initialize(IWorldData worldData);
        void LoadContent(IContentLoader contentLoader);
        void Update(double gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
