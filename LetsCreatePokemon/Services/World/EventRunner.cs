using System.Collections.Generic;
using System.Collections.ObjectModel;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.World.Events;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.World
{
    internal class EventRunner : IEventRunner
    {
        private IWorldData worldData;
        private int currentIndex;
        private IReadOnlyList<IEvent> currentEvents;
        private readonly IContentLoader contentLoader;

        public EventRunner(IContentLoader contentLoader)
        {
            this.contentLoader = contentLoader;
        }

        public void LoadContent(IWorldData worldData)
        {
            this.worldData = worldData;
        }

        public void RunEvents(IList<IEvent> events)
        {
            if (currentEvents != null)
                return; 
            currentEvents = new ReadOnlyCollection<IEvent>(events);
            currentIndex = 0;
            foreach (var currentEvent in currentEvents)
            {
                currentEvent.LoadContent(contentLoader);
            }
            currentEvents[currentIndex].Initialize(worldData);
            Input.LockInput = true; 
        }

        public void Update(double gameTime)
        {
            if (currentEvents == null)
                return;
            currentEvents[currentIndex].Update(gameTime);
            if(currentEvents[currentIndex].IsDone)
            {
                currentIndex++;
                if (currentIndex >= currentEvents.Count)
                {
                    currentEvents = null;
                    Input.LockInput = false;
                }
                else
                {
                    currentEvents[currentIndex].Initialize(worldData);
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentEvents?[currentIndex].Draw(spriteBatch);
        }
    }
}
