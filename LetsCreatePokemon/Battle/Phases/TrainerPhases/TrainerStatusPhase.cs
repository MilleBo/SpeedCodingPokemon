using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Battle.UI;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    class TrainerStatusPhase : IPhase
    {
        private readonly List<TrainerSprite> trainerSprites;
        private List<TrainerPokemonStatus> trainerPokemonStatuses;
        public bool IsDone { get; set; }

        public TrainerStatusPhase(List<TrainerSprite> trainerSprites)
        {
            this.trainerSprites = trainerSprites;
        }


        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData)
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
            return new TrainerMessagePhase(trainerSprites, trainerPokemonStatuses);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
