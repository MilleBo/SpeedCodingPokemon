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
        private readonly Dictionary<Directions, int> animationPosition;
        private readonly int width;
        private readonly int height;
        private readonly int animationFramesCount;
        private int animationIndex;
        private Directions direction;  

        public int AnimationSpeed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public AnimationWalking(int width, int height, int animationFramesCount, Directions direction)
        {
            this.width = width;
            this.height = height;
            this.animationFramesCount = animationFramesCount;
            this.direction = direction;
            AnimationSpeed = 200;
            animationPosition = new Dictionary<Directions, int>
            {
                [Directions.Down] = 0,
                [Directions.Up] = 1,
                [Directions.Left] = 2,
                [Directions.Right] = 3,
            };
        }

        public Rectangle GetNewAnimationState()
        {
            animationIndex++;
            if (animationIndex > animationFramesCount)
            {
                animationIndex = 0; 
            }
            return new Rectangle(width*animationIndex, height*animationPosition[direction], width, height);
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
