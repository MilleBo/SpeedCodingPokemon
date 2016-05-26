using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Pokemons.Battle.EnterBattleAnimations
{
    class EnterBattleAnimationTransparent : IEnterBattleAnimation
    {
        private const int SizeGrowthSpeed = 1;
        private const int ColorAlphaGrowthSpeed = 4;
        private readonly PokemonBattleSpriteData pokemonBattleSpriteData;
        public bool IsDone { get; private set; }

        public EnterBattleAnimationTransparent(PokemonBattleSpriteData pokemonBattleSpriteData)
        {
            this.pokemonBattleSpriteData = pokemonBattleSpriteData;
        }

        public void StartBattleAnimation()
        {
            IsDone = false;
            pokemonBattleSpriteData.Width = 0;
            pokemonBattleSpriteData.Height = 0;
            pokemonBattleSpriteData.Color = Color.Transparent;

        }

        public void Update(double gameTime)
        {
            if (IsDone) return;
            if (pokemonBattleSpriteData.Width != 50)
            {
                pokemonBattleSpriteData.Width += SizeGrowthSpeed;
                pokemonBattleSpriteData.Height += SizeGrowthSpeed;
            }
            if (pokemonBattleSpriteData.Color.A != 255)
            {
                pokemonBattleSpriteData.Color = new Color(Color.White, pokemonBattleSpriteData.Color.A + ColorAlphaGrowthSpeed);
            }
            IsDone = pokemonBattleSpriteData.Width == 50 && pokemonBattleSpriteData.Color.A == 255;
        }
    }
}
