using LetsCreatePokemon.Pokemons.Data;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Battle.UI
{
    class PlayerPokemonStateBar : PokemonStateBar
    {
        private double directionCounter;
        private bool isGoingUp;

        public PlayerPokemonStateBar(IPokemonBattleData pokemonBattleData) : base(pokemonBattleData)
        {
            BasePosition = new Vector2(120, 70);
            directionCounter = 0;
            isGoingUp = true; 
        }

        public override void Update(double gameTime)
        {
            base.Update(gameTime);
            directionCounter += gameTime;
            if (directionCounter > 500)
            {
                BasePosition.Y += isGoingUp ? 1 : -1;
                directionCounter = 0;
                isGoingUp = !isGoingUp;
            }
        }
    }
}
