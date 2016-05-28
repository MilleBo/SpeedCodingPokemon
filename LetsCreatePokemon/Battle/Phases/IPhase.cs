using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases
{
    internal interface IPhase
    {
        bool IsDone { get; }
        void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData);
        void Update(double gameTime);
        IPhase GetNextPhase();
        void Draw(SpriteBatch spriteBatch);
    }
}
