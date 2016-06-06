namespace LetsCreatePokemon.Battle.Common.PokeBallEnterAnimations
{
    internal interface IPokeBallEnterAnimation
    {
        bool IsDone { get; }
        void Update(double gameTime, PokeBallData pokeBallData);
    }
}
