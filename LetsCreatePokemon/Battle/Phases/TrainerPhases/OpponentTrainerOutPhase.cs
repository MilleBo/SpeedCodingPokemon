using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    class OpponentTrainerOutPhase : IPhase
    {
        private readonly Trainer trainer;
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        private readonly IWindowQueuer windowQueuer;
        public bool IsDone { get; private set; }

        public OpponentTrainerOutPhase(Trainer trainer, List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses, IWindowQueuer windowQueuer)
        {
            this.trainer = trainer;
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
            this.windowQueuer = windowQueuer;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            foreach (var trainerSprite in trainerSprites.Where(t => t is TrainerOpponentSprite))
            {
                trainerSprite.StartMoveOut();
            }
            foreach (var trainerPokemonStatuse in trainerPokemonStatuses.Where(t => t is TrainerOpponentPokemonStatus))
            {
                trainerPokemonStatuse.StartMoveOut();
            }
        }

        public void Update(double gameTime)
        {
            trainerSprites.ForEach(t => t.Update(gameTime));
            trainerPokemonStatuses.ForEach(t => t.Update(gameTime));
            IsDone = trainerSprites.TrueForAll(t => t.IsDone);
        }

        public IPhase GetNextPhase()
        {
           return new OpponentTrainerFirstPokemonPhase(trainer, trainerSprites, trainerPokemonStatuses, windowQueuer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
