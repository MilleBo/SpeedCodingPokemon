using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.Common;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    class OpponentTrainerFirstPokemonPhase : IPhase
    {
        private readonly Trainer trainer;
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        private readonly IWindowQueuer windowQueuer;
        private readonly PokeBall pokeBall; 
        public bool IsDone { get; private set; }

        public OpponentTrainerFirstPokemonPhase(Trainer trainer, List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses, IWindowQueuer windowQueuer)
        {
            this.trainer = trainer;
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
            this.windowQueuer = windowQueuer;
            pokeBall = new PokeBall(new Vector2(165, 55));
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            pokeBall.LoadContent(contentLoader);
        }

        public void Update(double gameTime)
        {
            pokeBall.Update(gameTime);
        }

        public IPhase GetNextPhase()
        {
            return null; 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pokeBall.Draw(spriteBatch);
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }


    }
}
