using System.Collections.Generic;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    internal class TrainerStartPhase : IPhase
    {
        private readonly Trainer trainer;
        private readonly IWindowQueuer windowQueuer;
        private List<TrainerSprite> trainerSprites;
        public bool IsDone { get; set; }

        public TrainerStartPhase(Trainer trainer, IWindowQueuer windowQueuer)
        {
            this.trainer = trainer;
            this.windowQueuer = windowQueuer;            
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            trainerSprites = new List<TrainerSprite>
            {
                new TrainerOpponentSprite(trainer.TextureName),
                new TrainerPlayerSprite("Trainers/trainer_back_single")
            };
            trainerSprites.ForEach(t => t.LoadContent(contentLoader));
        }

        public void Update(double gameTime)
        {
            trainerSprites.ForEach(t => t.Update(gameTime));
            IsDone = trainerSprites.TrueForAll(t => t.IsDone);
        }

        public IPhase GetNextPhase()
        {
            return new TrainerStatusPhase(trainer, trainerSprites, windowQueuer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
