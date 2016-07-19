using System.Collections.Generic;
using LetsCreatePokemon.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.UI
{
    internal class TrainerPlayerPokemonStatus : TrainerPokemonStatus
    {
        public override bool IsDone => Speed > -0.1f;

        public TrainerPlayerPokemonStatus(IList<PokemonStates> states) : base(states)
        {
            Position = new Vector2(240, 90);
            Speed = -5.0f;
        }

        public override void StartMoveOut()
        {
            Speed = -15.0f; 
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BarTexture, Position, Color.White);
            for (int n = 0; n < PokemonBallTextures.Count; n++)
            {
                spriteBatch.Draw(PokemonBallTextures[n], Position + new Vector2(20 + 10*n,1));
            }
        }
    }
}
