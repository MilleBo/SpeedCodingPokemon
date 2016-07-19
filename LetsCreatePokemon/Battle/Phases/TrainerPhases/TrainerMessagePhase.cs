using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Battle.UI;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using LetsCreatePokemon.Services.Windows.Message;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    class TrainerMessagePhase : IPhase
    {
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        private IWindowQueuer windowQueuer;
        public bool IsDone { get; set; }

        public TrainerMessagePhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses)
        {
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData)
        {
            this.windowQueuer = windowQueuer;
            windowQueuer.QueueWindow(new WindowBattleMessage($"{battleData.Opponent.Name} would like to battle! {Environment.NewLine} {battleData.Opponent.Name} sent out Weedle!", new InputKeyboard()));
        }

        public void Update(double gameTime)
        {
            IsDone = !windowQueuer.WindowActive;
        }

        public IPhase GetNextPhase()
        {
            return new OpponentTrainerOutPhase(trainerSprites, trainerPokemonStatuses);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
