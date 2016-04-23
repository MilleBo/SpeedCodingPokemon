using System;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Battle.TrainerSprites
{
    internal class TrainerPlayerSprite : TrainerSprite
    {
        public TrainerPlayerSprite(string textureName) : base(textureName)
        {
            Position = new Vector2(240, 48);
            WantedPosition = new Vector2(20, 48);
        }

        protected override void Move()
        {
            Position -= new Vector2(3, 0);
        }

        public override void StartMoveOut()
        {
            WantedPosition = new Vector2(-64, 48);
        }
    }
}
