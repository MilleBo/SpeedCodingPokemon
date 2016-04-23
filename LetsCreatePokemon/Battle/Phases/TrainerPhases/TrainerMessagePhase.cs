using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using LetsCreatePokemon.Services.Windows.Message;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    class TrainerMessagePhase : IPhase
    {
        private readonly Trainer trainer;
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        private readonly IWindowQueuer windowQueuer;
        public bool IsDone { get; }

        public TrainerMessagePhase(Trainer trainer, List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses, IWindowQueuer windowQueuer)
        {
            this.trainer = trainer;
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
            this.windowQueuer = windowQueuer;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            windowQueuer.QueueWindow(new WindowBattleMessage($"{trainer.Name} would like to battle! {Environment.NewLine} {trainer.Name} sent out Weedle!", new InputKeyboard()));
        }

        public void Update(double gameTime)
        {
            
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
