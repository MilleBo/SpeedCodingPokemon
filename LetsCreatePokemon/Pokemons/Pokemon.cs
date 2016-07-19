using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Pokemons.Data;

namespace LetsCreatePokemon.Pokemons
{
    class Pokemon
    {
        public IPokemonBattleData PokemonBattleData { get; }

        public Pokemon()
        {
            PokemonBattleData = new PokemonData
            {
                CurrentHealth = 21,
                MaxHealth = 21,
                ExperiencePercent = 50,
                Gender = Genders.Male,
                Level = 5,
                Name = "Weedle"
            };
        }
    }
}
