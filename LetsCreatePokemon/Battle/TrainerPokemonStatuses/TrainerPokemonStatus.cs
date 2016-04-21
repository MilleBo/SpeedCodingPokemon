using System;
using System.Collections.Generic;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.TrainerPokemonStatuses
{
    internal abstract class TrainerPokemonStatus
    {
        private const int SpeedDowngradeCooldown = 220;
        private const float SpeedDowngradeMultiplier = 0.3f;
        private readonly IList<PokemonStates> states;
        protected IList<Texture2D> PokemonBallTextures;
        protected Texture2D BarTexture;
        protected Vector2 Position;
        protected float Speed;
        private double counter;

        public bool IsDone { get; set; }

        protected TrainerPokemonStatus(IList<PokemonStates> states)
        {
            this.states = states;
            PokemonBallTextures = new List<Texture2D>();
            counter = 0; 
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            BarTexture = contentLoader.LoadTexture("Battle/Gui/BattleNumberOfPokemons");
            LoadPokemonBallTextures(contentLoader);
        }

        private void LoadPokemonBallTextures(IContentLoader contentLoader)
        {
            foreach (var pokemonState in states)
            {
                PokemonBallTextures.Add(
                    contentLoader.LoadTexture(
                        $"Battle/gui/StatusPokemonBall{Enum.GetName(typeof (PokemonStates), pokemonState)}"));
            }    
        }

        public void Update(double gameTime)
        {
            Position += new Vector2(Speed, 0);
            counter += gameTime;
            if (counter > SpeedDowngradeCooldown)
            {
                Speed *= SpeedDowngradeMultiplier;
                counter = 0; 
            }
            AnimationDone();
        }

        protected abstract void AnimationDone();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
