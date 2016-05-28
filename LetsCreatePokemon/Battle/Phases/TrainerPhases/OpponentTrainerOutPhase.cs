using System.Collections.Generic;
using System.Linq;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    class OpponentTrainerOutPhase : IPhase
    {
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        public bool IsDone { get; private set; }

        public OpponentTrainerOutPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses)
        {
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData)
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
           return new OpponentTrainerFirstPokemonPhase(trainerSprites, trainerPokemonStatuses);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
