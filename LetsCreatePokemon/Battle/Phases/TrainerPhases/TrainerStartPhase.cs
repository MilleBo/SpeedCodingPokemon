using System.Collections.Generic;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    internal class TrainerStartPhase : IPhase
    {
        private List<TrainerSprite> trainerSprites;
        public bool IsDone { get; set; }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData)
        {
            trainerSprites = new List<TrainerSprite>
            {
                new TrainerOpponentSprite(battleData.Opponent.TextureName),
                new TrainerPlayerSprite("Trainers/trainer_back")
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
            return new TrainerStatusPhase(trainerSprites);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
