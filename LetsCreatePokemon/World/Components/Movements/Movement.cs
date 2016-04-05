using System;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Services;
using LetsCreatePokemon.World.Components.Animations;
using LetsCreatePokemon.World.Components.Tiles;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Components.Movements
{
    internal class Movement : Component, IUpdateComponent
    {
        private readonly float speed;
        protected Vector2 wantedPosition;
        private readonly AnimationWalking animationWalking;
        public bool InMovement { get; private set; }

        public Movement(IComponentOwner owner, float speed) : base(owner)
        {
            this.speed = speed;
            InMovement = false; 
            animationWalking = new AnimationWalking(16, 20, 2, Directions.Down);
        }

        public void Move(Directions direction)
        {
            var sprite = Owner.GetComponent<Sprite>();
            var wantedTilePosition = sprite.TilePosition + UtilityService.ConvertDirectionToVector(direction);
            if (Collision((int)wantedTilePosition.X, (int)wantedTilePosition.Y))
                return; 
            wantedPosition = new Vector2(wantedTilePosition.X * Tile.Width, wantedTilePosition.Y * Tile.Height);
            InMovement = true;
            animationWalking.ChangeDirection(direction);
            Owner.GetComponent<Animation>().PlayAnimation(animationWalking);
        }

        private bool Collision(int wantedXTilePosition, int wantedYTilePostion)
        {
            var collision = Owner.GetComponent<Collision>();
            return collision != null && collision.CheckCollision(wantedXTilePosition, wantedYTilePostion);
        }

        public virtual void Update(double gameTime)
        {
            if (!InMovement)
                return;
            var sprite = Owner.GetComponent<Sprite>();
            var currentPosition = sprite.CurrentPosition;
            if (UtilityService.GetDistance(currentPosition, wantedPosition) < speed)
            {
                FinishMovement();
            }
            if (currentPosition.X < wantedPosition.X)
            {
                sprite.IncreasePositionOffset(speed, 0);
            }
            if (currentPosition.X > wantedPosition.X)
            {
                sprite.IncreasePositionOffset(speed*-1, 0);
            }
            if (currentPosition.Y < wantedPosition.Y)
            {
                sprite.IncreasePositionOffset(0, speed);
            }
            if (currentPosition.Y > wantedPosition.Y)
            {
                sprite.IncreasePositionOffset(0, speed*-1);
            }
        }

        private void FinishMovement()
        {
            var sprite = Owner.GetComponent<Sprite>();
            sprite.UpdateTilePosition((int) (wantedPosition.X/Tile.Width), (int) (wantedPosition.Y/Tile.Height));
            sprite.ResetPositionOffset();
            InMovement = false;
            var animation = Owner.GetComponent<Animation>();
            animation.StopAnimation();
        }
    }
}
