using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Common;

namespace LetsCreatePokemon.Pokemons.Data
{
    interface IPokemonBattleData
    {
        string Name { get; }
        int CurrentHealth { get; }
        int MaxHealth { get; }
        int ExperiencePercent { get; }
        Genders Gender { get; }
        int Level { get;  }
    }
}
