using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Common;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Components.Animations
{
    class AnimationSpinning : IAnimation
    {
        private readonly int width;
        private readonly int height;
        private readonly int[] directions;
        private int currentDirectionIndex; 
        public int AnimationCooldown { get; set; }

        public AnimationSpinning(int width, int height, int animationCooldown)
        {
            this.width = width;
            this.height = height;
            AnimationCooldown = animationCooldown;
            directions = new[]
            {
                (int) Directions.Left,
                (int) Directions.Up,
                (int) Directions.Right,
                (int) Directions.Down
            };
        }

        public Rectangle GetNewAnimationState()
        {
            currentDirectionIndex++;
            if (currentDirectionIndex > 3)
            {
                currentDirectionIndex = 0; 
            }
            return new Rectangle(width, height*directions[currentDirectionIndex], width, height);
        }
    }
}
