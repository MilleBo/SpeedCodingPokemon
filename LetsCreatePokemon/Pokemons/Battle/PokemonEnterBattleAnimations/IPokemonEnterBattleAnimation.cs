namespace LetsCreatePokemon.Pokemons.Battle.PokemonEnterBattleAnimations
{
    interface IPokemonEnterBattleAnimation
    {
        bool IsDone { get; }
        void StartBattleAnimation();
        void Update(double gameTime);
    }
}
