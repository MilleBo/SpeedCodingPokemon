using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Pokemons.Battle.PokemonEnterBattleAnimations
{
    class TransparentPokemonEnterBattleAnimation : IPokemonEnterBattleAnimation
    {
        protected const int SizeGrowthSpeed = 1;
        protected const int ColorAlphaGrowthSpeed = 4;
        protected const int FinalWidthAndHeight = 64;
        protected readonly PokemonBattleSpriteData PokemonBattleSpriteData;
        public bool IsDone { get; private set; }

        public TransparentPokemonEnterBattleAnimation(PokemonBattleSpriteData pokemonBattleSpriteData)
        {
            this.PokemonBattleSpriteData = pokemonBattleSpriteData;

        }

        public void StartBattleAnimation()
        {
            IsDone = false;
            PokemonBattleSpriteData.Width = 0;
            PokemonBattleSpriteData.Height = 0;
            PokemonBattleSpriteData.Color = Color.Transparent;

        }

        public virtual void Update(double gameTime)
        {
            if (IsDone) return;
            if (PokemonBattleSpriteData.Width != FinalWidthAndHeight)
            {
                PokemonBattleSpriteData.Width += SizeGrowthSpeed;
                PokemonBattleSpriteData.Height += SizeGrowthSpeed;
            }
            if (PokemonBattleSpriteData.Color.A != 255)
            {
                PokemonBattleSpriteData.Color = new Color(Color.White, PokemonBattleSpriteData.Color.A + ColorAlphaGrowthSpeed);
            }
            IsDone = PokemonBattleSpriteData.Width == FinalWidthAndHeight && PokemonBattleSpriteData.Color.A == 255;
        }
    }
}
