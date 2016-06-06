using System;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Battle.Common.PokeBallEnterAnimations
{
    internal class PlayerCastingPokeBallEnterAnimation : IPokeBallEnterAnimation
    {
        private const int MovementDelayTime = 100;
        private Vector2 speed;
        private double counter;


        public bool IsDone { get; set; }

        public PlayerCastingPokeBallEnterAnimation()
        {
            speed = new Vector2(5f, -1.5f);
            counter = 0;
        }

        public void Update(double gameTime, PokeBallData pokeBallData)
        {
            pokeBallData.Rotation += MathHelper.WrapAngle(pokeBallData.Rotation + 0.1f);
            counter += gameTime;
            if (counter > MovementDelayTime)
            {
                pokeBallData.Position += speed;
                if (pokeBallData.Position.X > 55)
                {
                    speed.X = 0; 
                }
                speed.Y++;
                counter = 0; 
            }
            IsDone = pokeBallData.Position.Y > 100;
        }
    }
}
