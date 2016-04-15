using System;
using System.Collections.Generic;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases
{
    internal class PhaseTrainerIntro : IPhase
    {
        public bool IsDone { get; }
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses; 

        public PhaseTrainerIntro(Trainer trainer)
        {
            trainerSprites = new List<TrainerSprite>
            {
                new TrainerOpponentSprite(trainer.TextureName),
                new TrainerPlayerSprite("Trainers/trainer_back_single")
            };
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
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            trainerSprites.ForEach(t => t.LoadContent(contentLoader));
            trainerPokemonStatuses.ForEach(t => t.LoadContent(contentLoader));
        }

        public void Update(double gameTime)
        {
            trainerSprites.ForEach(t => t.Update(gameTime));
            trainerPokemonStatuses.ForEach(t => t.Update(gameTime));
        }

        public IPhase GetNextPhase()
        {
            return null; 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
