using LetsCreatePokemon.Common;

namespace LetsCreatePokemon.Pokemons.Data
{
    class PokemonData : IPokemonBattleData
    {
        public string Name { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int ExperiencePercent { get; set; }
        public Genders Gender { get; set; }
        public int Level { get; set; }
    }
}
