using System;
using System.Collections.Generic;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using LetsCreatePokemon.Services.Windows.Message;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases
{
    internal class PhaseTrainerIntro : IPhase
    {
        private enum Phases { ShowTrainers, ShowGui, ShowMessage }
        private Phases currentPhases;
        private readonly Trainer trainer;
        private readonly IWindowQueuer windowQueuer;
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        public bool IsDone { get; }

        public PhaseTrainerIntro(Trainer trainer, IWindowQueuer windowQueuer)
        {
            this.trainer = trainer;
            this.windowQueuer = windowQueuer;
            currentPhases = Phases.ShowTrainers;
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
            switch (currentPhases)
            {
                case Phases.ShowTrainers:
                    ShowTrainers(gameTime);
                    break;
                case Phases.ShowGui:
                    ShowGui(gameTime);
                    break;
                case Phases.ShowMessage:
                    ShowMessage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ShowTrainers(double gameTime)
        {
            trainerSprites.ForEach(t => t.Update(gameTime));
            if (trainerSprites.TrueForAll(t => t.IsDone))
            {
                currentPhases = Phases.ShowGui;
            }
        }

        private void ShowGui(double gameTime)
        {
            trainerPokemonStatuses.ForEach(t => t.Update(gameTime));
            if (trainerPokemonStatuses.TrueForAll(t => t.IsDone))
            {
                currentPhases = Phases.ShowMessage;
                windowQueuer.QueueWindow(new WindowBattleMessage($"{trainer.Name} would like to battle! {Environment.NewLine} {trainer.Name} sent out Weedle!", new InputKeyboard()));
            }
        }

        private void ShowMessage()
        {
            if (windowQueuer.WindowActive)
                return;
            //Go to next phase 
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
