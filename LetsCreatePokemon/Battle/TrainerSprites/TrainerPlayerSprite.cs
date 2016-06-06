using System;
using Windows.UI.Xaml.Media.Animation;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Battle.TrainerSprites
{
    internal class TrainerPlayerSprite : TrainerSprite
    {
        private const int FrameCount = 4;
        private const int FrameTime = 100;

        private double counter;
        private int frameIndex;
        private int speed;
        private bool isMovingOut; 

        public TrainerPlayerSprite(string textureName) : base(textureName)
        {
            Position = new Vector2(240, 48);
            WantedPosition = new Vector2(20, 48);
            speed = 3;
            isMovingOut = false;
            frameIndex = 0; 
        }

        protected override void Move(double gameTime)
        {
            Position -= new Vector2(speed, 0);
            if (isMovingOut && frameIndex < FrameCount)
            {
                counter += gameTime;
                if (counter > FrameTime)
                {
                    counter = 0;
                    frameIndex++; 
                    DrawRectangle = new Rectangle(TrainerTextureWidth*frameIndex, 0, TrainerTextureWidth, TrainerTextureHeight);
                }
            }

        }

        public override void StartMoveOut()
        {
            WantedPosition = new Vector2(-64, 48);
            speed = 1;
            isMovingOut = true; 
        }
    }
}
