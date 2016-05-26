namespace LetsCreatePokemon.Pokemons.Battle.EnterBattleAnimations
{
    interface IEnterBattleAnimation
    {
        bool IsDone { get; }
        void StartBattleAnimation();
        void Update(double gameTime);
    }
}
