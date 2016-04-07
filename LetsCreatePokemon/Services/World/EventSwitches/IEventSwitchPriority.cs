using System.Collections.Generic;

namespace LetsCreatePokemon.Services.World.EventSwitches
{
    internal interface IEventSwitchPriority
    {
        IList<int> GetPrioritizedEventIds(IList<int> eventSwitchIds);
    }
}
