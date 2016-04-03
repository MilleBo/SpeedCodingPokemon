using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.World.Events;

namespace LetsCreatePokemon.World.EventTriggers
{
    internal abstract class EventTrigger : Component, IUpdateComponent
    {
        private readonly IEventRunner eventRunner;
        private readonly IList<IEvent> events;

        protected EventTrigger(IComponentOwner owner, IEventRunner eventRunner, IList<IEvent> events) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.events = events;
        }

        public void Update(double gameTime)
        {
            if (ShouldTriggerEvents())
            {
                eventRunner.RunEvents(events);
            }
        }

        protected abstract bool ShouldTriggerEvents();
    }
}
