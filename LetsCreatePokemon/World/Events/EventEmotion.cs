using System.Collections.Generic;
using System.Linq;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.World.Components;
using LetsCreatePokemon.World.Emotions;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Events
{
    internal class EventEmotion : IEvent
    {
        private readonly string entityId;
        private readonly IReadOnlyList<Entity> entities;
        private readonly IEmotion emotion;
        public bool IsDone { get; private set; }

        public EventEmotion(string entityId, IReadOnlyList<Entity> entities, IEmotion emotion)
        {
            this.entityId = entityId;
            this.entities = entities;
            this.emotion = emotion;
        }

        public void Initialize()
        {
            var entity = entities.FirstOrDefault(e => e.Id == entityId);
            if (entity == null)
            {
                IsDone = true;
            }
            else
            {
                var sprite = entity.GetComponent<Sprite>();
                emotion.PlayEmotion((int)sprite.TilePosition.X, (int)sprite.TilePosition.Y-1);
            }
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            emotion.LoadContent(contentLoader);
        }

        public void Update(double gameTime)
        {
            emotion.Update(gameTime);
            if (emotion.IsDone)
            {
                IsDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            emotion.Draw(spriteBatch);
        }
    }
}
