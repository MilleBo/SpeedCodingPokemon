using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Pokemons.Battle
{
    interface IPokemonBattleSprite
    {
        void LoadContent(IContentLoader contentLoader);
        void Draw(SpriteBatch spriteBatch);
    }
}
