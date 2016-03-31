using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Data;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.World.Components;
using LetsCreatePokemon.World.Components.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Emotions
{
    internal class EmotionTrainer : IEmotion
    {
        private const int EmotionTime = 1000;
        private readonly Entity entity;
        private double counter;
        private float extraY; 
        public bool IsDone { get; private set; }

        public EmotionTrainer()
        {
            entity = new Entity("emotion");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Height = 16,
                Width = 16,
                TextureName = "Emotions/trainer_b"
            }));
            entity.AddComponent(new Animation(entity));
        }

        public void PlayEmotion(int xTilePosition, int yTilePosition)
        {
            IsDone = false;
            counter = 0;
            extraY = -5;
            entity.GetComponent<Sprite>().UpdateTilePosition(xTilePosition, yTilePosition);
            entity.GetComponent<Animation>().PlayAnimation(new AnimationEmotion());
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            entity.LoadContent(contentLoader);
        }

        public void Update(double gameTime)
        {
            entity.Update(gameTime);
            counter += gameTime;
            if (counter > EmotionTime)
            {
                IsDone = true; 
            }
            //For the extra bounce
            if (extraY < 6)
            {
                entity.GetComponent<Sprite>().IncreasePositionOffset(0, extraY);
                extraY++; 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            entity.Draw(spriteBatch);
        }
    }
}
