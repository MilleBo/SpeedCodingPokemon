using System;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Battle.TrainerSprites
{
    class TrainerOpponentSprite : TrainerSprite
    {
        public TrainerOpponentSprite(string textureName) : base(textureName)
        {
            position = new Vector2(-64, 10);
        }

        public override void Update(double gameTime)
        {
            if (Math.Abs(position.X - 140) < 5)
            {
                IsDone = true;
            }
            else
            {
                position += new Vector2(3, 0);
            }
        }
    }
}
