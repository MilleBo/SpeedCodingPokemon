using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Common;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Components.Animations
{
    internal class AnimationWalking : IAnimation
    {
        private readonly int width;
        private readonly int height;
        private readonly int animationFramesCount;
        private int animationIndex;
        private Directions direction;  

        public int AnimationCooldown { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public AnimationWalking(int width, int height, int animationFramesCount, Directions direction)
        {
            this.width = width;
            this.height = height;
            this.animationFramesCount = animationFramesCount;
            this.direction = direction;
            AnimationCooldown = 200;
        }

        public Rectangle GetNewAnimationState()
        {
            animationIndex++;
            if (animationIndex > animationFramesCount)
            {
                animationIndex = 0; 
            }
            return new Rectangle(width*animationIndex, height*(int)direction, width, height);
        }

        public void ChangeDirection(Directions newDirection)
        {
            if (direction == newDirection)
                return;
            direction = newDirection;
            animationIndex = 0; 
        }
    }
}
