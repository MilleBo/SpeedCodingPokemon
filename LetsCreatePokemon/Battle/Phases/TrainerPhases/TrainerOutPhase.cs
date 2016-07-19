using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Battle.UI;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    internal abstract class TrainerOutPhase<TTrainerSprite, TTrainerStatusSprite> : IPhase where TTrainerSprite : TrainerSprite where TTrainerStatusSprite : TrainerPokemonStatus
    {
        protected readonly List<TrainerSprite> TrainerSprites;
        protected readonly List<TrainerPokemonStatus> TrainerPokemonStatuses;
        public bool IsDone { get; protected set; }


        protected TrainerOutPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses)
        {
            this.TrainerSprites = trainerSprites;
            this.TrainerPokemonStatuses = trainerPokemonStatuses;
        }

        public virtual void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData)
        {
            foreach (var trainerSprite in TrainerSprites.Where(t => t is TTrainerSprite))
            {
                trainerSprite.StartMoveOut();
            }
            foreach (var trainerPokemonStatuse in TrainerPokemonStatuses.Where(t => t is TTrainerStatusSprite))
            {
                trainerPokemonStatuse.StartMoveOut();
            }
        }

        public virtual void Update(double gameTime)
        {
            TrainerSprites.ForEach(t => t.Update(gameTime));
            TrainerPokemonStatuses.ForEach(t => t.Update(gameTime));
            IsDone = TrainerSprites.TrueForAll(t => t.IsDone);
        }

        public abstract IPhase GetNextPhase();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            TrainerSprites.ForEach(t => t.Draw(spriteBatch));
            TrainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
