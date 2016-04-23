using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    class TrainerStatusPhase : IPhase
    {
        private readonly Trainer trainer;
        private readonly List<TrainerSprite> trainerSprites;
        private readonly IWindowQueuer windowQueuer;
        private List<TrainerPokemonStatus> trainerPokemonStatuses;
        public bool IsDone { get; set; }

        public TrainerStatusPhase(Trainer trainer, List<TrainerSprite> trainerSprites, IWindowQueuer windowQueuer)
        {
            this.trainer = trainer;
            this.trainerSprites = trainerSprites;
            this.windowQueuer = windowQueuer;
        }


        public void LoadContent(IContentLoader contentLoader)
        {
            trainerPokemonStatuses = new List<TrainerPokemonStatus>
            {
                new TrainerOpponentPokemonStatus(new List<PokemonStates>
                {
                    PokemonStates.Normal,
                    PokemonStates.StatusEffect
                }),
                new TrainerPlayerPokemonStatus(new List<PokemonStates>
                {
                    PokemonStates.Normal,
                    PokemonStates.Dead,
                    PokemonStates.StatusEffect
                })
            };
            trainerPokemonStatuses.ForEach(t => t.LoadContent(contentLoader));
        }

        public void Update(double gameTime)
        {
            trainerPokemonStatuses.ForEach(t => t.Update(gameTime));
            IsDone = trainerPokemonStatuses.TrueForAll(t => t.IsDone);
        }

        public IPhase GetNextPhase()
        {
            return new TrainerMessagePhase(trainer, trainerSprites, trainerPokemonStatuses, windowQueuer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
