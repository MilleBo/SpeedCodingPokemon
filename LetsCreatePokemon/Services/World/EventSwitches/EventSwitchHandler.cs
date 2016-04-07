using System.Collections.Generic;
using System.Linq;

namespace LetsCreatePokemon.Services.World.EventSwitches
{
    internal class EventSwitchHandler : IEventSwitchPriority, IEventSwitchUpdater
    {
        public const int DefaultEventSwitchId = 0;
        private readonly IList<EventSwitch> eventSwitches;

        public EventSwitchHandler()
        {
            eventSwitches = new List<EventSwitch>
            {
                new EventSwitch {Id = DefaultEventSwitchId, Name = "Default", On = true}
            };
        }

        public void AddEventSwitch(EventSwitch eventSwitch)
        {
            eventSwitches.Add(eventSwitch); 
        }
            
        public IList<int> GetPrioritizedEventIds(IList<int> eventSwitchIds)
        {
            var prioritizedEventIds = new List<int> {DefaultEventSwitchId};
            var events = eventSwitches.Where(e => eventSwitchIds.Contains(e.Id) && e.On && e.Id != DefaultEventSwitchId);
            if (events.Any())
            {
                prioritizedEventIds.Add(events.Max(e => e.Id));
            }
            return prioritizedEventIds;
        }

        public void UpdateEventSwitch(int id, bool @on)
        {
            if (id == DefaultEventSwitchId)
                return;
            var eventSwitch = eventSwitches.FirstOrDefault(e => e.Id == id);
            if (eventSwitch != null)
            {
                eventSwitch.On = @on; 
            }
        }
    }
}
