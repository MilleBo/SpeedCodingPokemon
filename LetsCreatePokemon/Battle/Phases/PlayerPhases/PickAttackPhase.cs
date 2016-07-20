using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Battle.UI;
using LetsCreatePokemon.Pokemons;
using LetsCreatePokemon.Pokemons.Battle;
using LetsCreatePokemon.Pokemons.Data;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Phases.PlayerPhases
{
    class PickAttackPhase : IPhase
    {
        private readonly IPokemonBattleSprite playerPokemonBattleSprite;
        private readonly IPokemonBattleSprite opponenPokemonBattleSprite;
        private PokemonStateBar playerPokemonStateBar;
        public bool IsDone { get; }

        //FOR HEALTHBAR TEST
        private double counter; 
        private Random rnd = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public PickAttackPhase(IPokemonBattleSprite playerPokemonBattleSprite, IPokemonBattleSprite opponenPokemonBattleSprite)
        {
            this.playerPokemonBattleSprite = playerPokemonBattleSprite;
            this.opponenPokemonBattleSprite = opponenPokemonBattleSprite;
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, BattleData battleData)
        {
            playerPokemonStateBar = new PlayerPokemonStateBar(new Pokemon().PokemonBattleData); //temporary
            playerPokemonStateBar.LoadContent(contentLoader);
        }

        public void Update(double gameTime)
        {
            playerPokemonStateBar.Update(gameTime);

            //HEALTHBAR TEST
            counter += gameTime;
            if (counter > 1000)
            {
                playerPokemonStateBar.HealthBar.UpdateHealth(rnd.Next(0, 21), 21);
                counter = 0;
            }
        }

        public IPhase GetNextPhase()
        {
            return null; 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerPokemonBattleSprite.Draw(spriteBatch);
            opponenPokemonBattleSprite.Draw(spriteBatch);
            playerPokemonStateBar.Draw(spriteBatch);
        }
    }
}
