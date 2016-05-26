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
            spriteBatch.Draw(texture, pokemonBattleSpriteDate.DrawRectangle, new Rectangle(0, 0, texture.Width, texture.Height), 
                pokemonBattleSpriteDate.Color, 0f, new Vector2(texture.Width/2, texture.Height/2), SpriteEffects.None, 0);
        }


    }
}
