using LetsCreatePokemon.Battle;

namespace LetsCreatePokemon.Services.Content
{
    internal class TrainerTestLoader : ITrainerLoader
    {
        public Trainer LoadTrainer(int id)
        {
            return new Trainer {Id = id, Name = "BUG CATCHER RICK", TextureName = "Trainers/bug_catcher"};
        }
    }
}
