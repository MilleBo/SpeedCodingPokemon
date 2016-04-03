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
        private readonly WorldObject worldObject;
        private double counter;
        private float extraY; 
        public bool IsDone { get; private set; }

        public EmotionTrainer()
        {
            worldObject = new WorldObject("emotion");
            worldObject.AddComponent(new Sprite(worldObject, new SpriteData
            {
                Color = Color.White,
                Height = 16,
                Width = 16,
                TextureName = "Emotions/trainer_b"
            }));
            worldObject.AddComponent(new Animation(worldObject));
        }

        public void PlayEmotion(int xTilePosition, int yTilePosition)
        {
            IsDone = false;
            counter = 0;
            extraY = -5;
            worldObject.GetComponent<Sprite>().ResetPositionOffset();
            worldObject.GetComponent<Sprite>().UpdateTilePosition(xTilePosition, yTilePosition);
            worldObject.GetComponent<Animation>().PlayAnimation(new AnimationEmotion());
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            worldObject.GetComponents<ILoadContentComponent>().ForEach(c => c.LoadContent(contentLoader));
        }

        public void Update(double gameTime)
        {
            worldObject.GetComponents<IUpdateComponent>().ForEach(c => c.Update(gameTime));
            counter += gameTime;
            if (counter > EmotionTime)
            {
                IsDone = true; 
            }
            //For the extra bounce
            if (extraY < 6)
            {
                worldObject.GetComponent<Sprite>().IncreasePositionOffset(0, extraY);
                extraY++; 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            worldObject.GetComponents<IDrawComponent>().ForEach(c => c.Draw(spriteBatch));
        }
    }
}
