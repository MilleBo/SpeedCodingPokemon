using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.Common;
using LetsCreatePokemon.Battle.TrainerPokemonStatuses;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Pokemons.Battle;
using LetsCreatePokemon.Pokemons.Battle.EnterBattleAnimations;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.TrainerPhases
{
    class OpponentTrainerFirstPokemonPhase : IPhase
    {
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        private readonly PokeBall pokeBall;
        private readonly IPokemonBattleSprite pokemonBattleSpriteTest;
        public bool IsDone { get; private set; }

        public OpponentTrainerFirstPokemonPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses)
        {
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
            PokemonBattleSprite pokemonBattleSpriteTest = new PokemonBattleSprite(new PokemonBattleSpriteData(0, 0, new Vector2(165, 55), Color.White, "Pokemons/weedle_front"));
            pokeBall = new PokeBall(new Vector2(165, 55), new EnterBattleAnimationTransparent(pokemonBattleSpriteTest.GetPokemonBattleSpriteData()));
            this.pokemonBattleSpriteTest = pokemonBattleSpriteTest;
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData)
        {
            pokeBall.LoadContent(contentLoader);
            pokemonBattleSpriteTest.LoadContent(contentLoader);
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
            pokemonBattleSpriteTest.Draw(spriteBatch);
        }


    }
}
