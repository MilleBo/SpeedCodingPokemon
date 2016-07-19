using System.Collections.Generic;
using System.Linq;
using LetsCreatePokemon.Battle.Common;
using LetsCreatePokemon.Battle.Common.PokeBallEnterAnimations;
using LetsCreatePokemon.Battle.Phases.TrainerPhases;
using LetsCreatePokemon.Battle.TrainerSprites;
using LetsCreatePokemon.Battle.UI;
using LetsCreatePokemon.Pokemons.Battle;
using LetsCreatePokemon.Pokemons.Battle.PokemonEnterBattleAnimations;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.PlayerPhases
{
    class PlayerTrainerOutPhase : TrainerOutPhase<TrainerPlayerSprite, TrainerPlayerPokemonStatus>
    {
        private readonly IPokemonBattleSprite opponentPokemonBattleSprite;
        private readonly IPokemonBattleSprite pokemonBattleSpriteTest;
        private readonly PokeBall pokeBall;

        public PlayerTrainerOutPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses, IPokemonBattleSprite opponentPokemonBattleSprite) : base(trainerSprites, trainerPokemonStatuses)
        {
            this.opponentPokemonBattleSprite = opponentPokemonBattleSprite;
            PokemonBattleSprite pokemonBattleSpriteTest = new PokemonBattleSprite(new PokemonBattleSpriteData(0, 0, new Vector2(50, 160), Color.White, "Pokemons/charmander", PokemonBattleSpriteData.PokemonFacings.Back));
            pokeBall = new PokeBall(new PokeBallData(new Vector2(0, 70), "Battle/Pokeballs/pokeball_regular"), new PlayerCastingPokeBallEnterAnimation(), new GrowPokemonEnterBattleAnimation(pokemonBattleSpriteTest.GetPokemonBattleSpriteData()));
            this.pokemonBattleSpriteTest = pokemonBattleSpriteTest;
        }

        public override void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData)
        {
            base.LoadContent(contentLoader, windowQueuer, battleData);
            pokeBall.LoadContent(contentLoader);
            pokemonBattleSpriteTest.LoadContent(contentLoader);
        }

        public override void Update(double gameTime)
        {
            base.Update(gameTime);
            if (!ShowPokeBall()) return; 
            pokeBall.Update(gameTime);
            IsDone = pokeBall.IsDone;
        }

        public bool ShowPokeBall()
        {
            return TrainerSprites.All(t => t.Position.X < 0);
        }

        public override IPhase GetNextPhase()
        {
            return new PickAttackPhase(pokemonBattleSpriteTest, opponentPokemonBattleSprite);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (ShowPokeBall())
            {
                pokeBall.Draw(spriteBatch);
            }
            pokemonBattleSpriteTest.Draw(spriteBatch);
            opponentPokemonBattleSprite.Draw(spriteBatch);
        }
    }
}
