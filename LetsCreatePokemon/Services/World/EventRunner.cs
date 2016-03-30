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
        private int currentIndex;
        private IReadOnlyList<IEvent> currentEvents;
        private readonly IContentLoader contentLoader;

        public EventRunner(IContentLoader contentLoader)
        {
            this.contentLoader = contentLoader;
        }

        public void RunEvents(IList<IEvent> events)
        {
            currentEvents = new ReadOnlyCollection<IEvent>(events);
            currentIndex = 0;
            foreach (var currentEvent in currentEvents)
            {
                currentEvent.LoadContent(contentLoader);
            }
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
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentEvents?[currentIndex].Draw(spriteBatch);
        }
    }
}
