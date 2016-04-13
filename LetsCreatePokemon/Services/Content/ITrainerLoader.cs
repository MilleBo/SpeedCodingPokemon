using LetsCreatePokemon.Battle;

namespace LetsCreatePokemon.Services.Content
{
    interface ITrainerLoader
    {
        Trainer LoadTrainer(int id);
    }
}
