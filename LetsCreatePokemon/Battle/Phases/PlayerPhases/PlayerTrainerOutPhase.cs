using System.Collections.Generic;
using LetsCreatePokemon.Battle.Phases.TrainerPhases;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;

namespace LetsCreatePokemon.Battle.Phases.PlayerPhases
{
    class PlayerTrainerOutPhase : TrainerOutPhase<TrainerPlayerSprite, TrainerPlayerPokemonStatus>
    {
        public PlayerTrainerOutPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses) : base(trainerSprites, trainerPokemonStatuses)
        {
        }

        public override void Update(double gameTime)
        {
            base.Update(gameTime);
            IsDone = false;
        }

        public override IPhase GetNextPhase()
        {
            return null; 
        }
    }
}
