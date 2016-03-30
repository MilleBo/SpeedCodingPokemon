using System.Collections.Generic;
using LetsCreatePokemon.World.Events;

namespace LetsCreatePokemon.Services.World
{
    internal interface IEventRunner
    {
        void RunEvents(IList<IEvent> events);
    }
}
