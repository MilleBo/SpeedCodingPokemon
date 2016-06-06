using System;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Battle.TrainerSprites
{
    class TrainerOpponentSprite : TrainerSprite
    {
        public TrainerOpponentSprite(string textureName) : base(textureName)
        {
            Position = new Vector2(-64, 10);
            WantedPosition = new Vector2(140, 10);
        }

        protected override void Move(double gameTime)
        {
            Position += new Vector2(3, 0);
        }

        public override void StartMoveOut()
        {
            WantedPosition = new Vector2(304, 10);
        }
    }
}
