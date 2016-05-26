using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Pokemons.Battle.EnterBattleAnimations;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.Common
{
    internal class PokeBall
    {
        private const int EffectCount = 30;
        private const int TimeUntilOpen = 200;
        private const int TimeOpen = 1000; 
        private const int PokeballWidth = 12;
        private const int PokeballHeight = 12; 

        private readonly Vector2 position;
        private readonly IEnterBattleAnimation enterBattleAnimation;
        private readonly List<PokeBallOpenEffect> pokeballOpenEffects;
        private Texture2D pokeballTexture;
        private IContentLoader contentLoader;
        private Random rnd; 
        private double counter;
        private bool isOpen;

        public bool IsDone { get; set; }

        public PokeBall(Vector2 position, IEnterBattleAnimation enterBattleAnimation)
        {
            this.position = position;
            this.enterBattleAnimation = enterBattleAnimation;
            pokeballOpenEffects = new List<PokeBallOpenEffect>();
            rnd = new Random();
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            pokeballTexture = contentLoader.LoadTexture("Battle/Pokeballs/pokeball_regular");
            this.contentLoader = contentLoader;
        }

        public void Update(double gameTime)
        {
            counter += gameTime;
            if (!isOpen && counter > TimeUntilOpen)
            {
                isOpen = true;
                counter = 0;
                CreatePokeballOpenEffects();
                enterBattleAnimation.StartBattleAnimation();
            }
            if (isOpen)
            {
                UpdateOpenPokeball(gameTime);
            }
        }

        private void UpdateOpenPokeball(double gameTime)
        {
            if (counter < TimeOpen)
            {
                pokeballOpenEffects.ForEach(p => p.Update(gameTime));
            }
            if (!enterBattleAnimation.IsDone)
            {
                enterBattleAnimation.Update(gameTime);
            }
            IsDone = counter > TimeOpen && enterBattleAnimation.IsDone;
        }

        private void CreatePokeballOpenEffects()
        {
            pokeballOpenEffects.Clear();
            for (int n = 0; n < EffectCount; n++)
            {
                Vector2 direction;
                do
                {
                    //Get a direction between -1 and 1.
                    direction = new Vector2((float) rnd.NextDouble()*2 - 1, (float) rnd.NextDouble()*2 - 1);
                } while (pokeballOpenEffects.Any(p => p.Direction == direction));
                var pokeballOpenEffect = new PokeBallOpenEffect(position, direction);
                pokeballOpenEffect.LoadContent(contentLoader);
                pokeballOpenEffects.Add(pokeballOpenEffect);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsDone) return; 
            spriteBatch.Draw(pokeballTexture, position, new Rectangle(PokeballWidth * (isOpen ? 1 : 0), 0, PokeballWidth, PokeballHeight), Color.White);
            pokeballOpenEffects.ForEach(p => p.Draw(spriteBatch));
        }
    }
}
