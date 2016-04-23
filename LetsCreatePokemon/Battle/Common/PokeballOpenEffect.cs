using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace LetsCreatePokemon.Battle.Common
{
    internal class PokeBallOpenEffect
    {
        private const int EffectWidth = 6;
        private const int EffectHeight = 6;
        private const int AnimationFrequency = 50;
        private const int EffectFrameCount = 3;

        private Vector2 position;
        private Texture2D effectTecture;
        private int animationIndex;
        private double counter; 

        public Vector2 Direction { get; }

        public PokeBallOpenEffect(Vector2 startPosition, Vector2 direction)
        {
            Direction = direction;
            position = startPosition;
        }


        public void LoadContent(IContentLoader contentLoader)
        {
            effectTecture = contentLoader.LoadTexture("Battle/Pokeballs/pokeball_open_effect");
        }

        public void Update(double gameTime)
        {
            position += Direction;
            counter += gameTime;
            if (counter > AnimationFrequency)
            {
                counter = 0;
                animationIndex++;
                if (animationIndex >= EffectFrameCount)
                {
                    animationIndex = 0; 
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(effectTecture, position, new Rectangle(EffectWidth*animationIndex, 0, EffectWidth, EffectHeight), Color.White);
        }
    }
}
