using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Pokemons.Battle.PokemonEnterBattleAnimations
{
    class GrowPokemonEnterBattleAnimation : TransparentPokemonEnterBattleAnimation
    {
        public GrowPokemonEnterBattleAnimation(PokemonBattleSpriteData pokemonBattleSpriteData) : base(pokemonBattleSpriteData)
        {
        }

        public override void Update(double gameTime)
        {
            base.Update(gameTime);
            if (PokemonBattleSpriteData.Position.Y > 145 - PokemonBattleSpriteData.Height)
            {
                PokemonBattleSpriteData.Position -= new Vector2(0, SizeGrowthSpeed*2);
            }
        }
    }
}
