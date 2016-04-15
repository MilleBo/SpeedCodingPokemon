using System;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Battle.TrainerSprites
{
    internal class TrainerPlayerSprite : TrainerSprite
    {
        public TrainerPlayerSprite(string textureName) : base(textureName)
        {
            position = new Vector2(240, 48);
        }

        public override void Update(double gameTime)
        {
            if (Math.Abs(position.X - 20) < 5)
                return;
            position -= new Vector2(3, 0);
        }
    }
}
