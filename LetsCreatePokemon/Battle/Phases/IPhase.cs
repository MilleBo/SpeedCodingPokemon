using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases
{
    internal interface IPhase
    {
        bool IsDone { get; }
        void LoadContent(IContentLoader contentLoader);
        void Update(double gameTime);
        IPhase GetNextPhase();
        void Draw(SpriteBatch spriteBatch);
    }
}
