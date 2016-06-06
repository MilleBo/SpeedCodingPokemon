using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Pokemons.Battle
{
    class PokemonBattleSprite : IPokemonBattleSprite, IPokemonBattleSpriteData
    {
        private Texture2D texture;
        private readonly PokemonBattleSpriteData pokemonBattleSpriteDate;

        public PokemonBattleSprite(PokemonBattleSpriteData pokemonBattleSpriteDate)
        {
            this.pokemonBattleSpriteDate = pokemonBattleSpriteDate;
        }

        public PokemonBattleSpriteData GetPokemonBattleSpriteData()
        {
            return pokemonBattleSpriteDate;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture(pokemonBattleSpriteDate.TextureName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pokemonBattleSpriteDate.Rectangle, pokemonBattleSpriteDate.DrawRectangle, 
                pokemonBattleSpriteDate.Color, 0f, new Vector2(PokemonBattleSpriteData.TextureWidth/ 2, PokemonBattleSpriteData.TextureHeight / 2), SpriteEffects.None, 0);
        }


    }
}
