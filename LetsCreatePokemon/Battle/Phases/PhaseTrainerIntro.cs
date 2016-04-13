using System;
using System.Collections.Generic;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases
{
    internal class PhaseTrainerIntro : IPhase
    {
        public bool IsDone { get; }
        private IList<TrainerSprite> trainerSprites; 

        public PhaseTrainerIntro(Trainer trainer)
        {
            trainerSprites = new List<TrainerSprite>
            {
                new TrainerOpponentSprite(trainer.TextureName),
                new TrainerPlayerSprite("Trainers/trainer_back_single")
            };
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            foreach (var trainerSprite in trainerSprites)
            {
                trainerSprite.LoadContent(contentLoader);
            }
        }

        public void Update(double gameTime)
        {
            foreach (var trainerSprite in trainerSprites)
            {
                trainerSprite.Update(gameTime);
            }
        }

        public IPhase GetNextPhase()
        {
            return null; 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var trainerSprite in trainerSprites)
            {
                trainerSprite.Draw(spriteBatch);
            }
        }
    }
}
