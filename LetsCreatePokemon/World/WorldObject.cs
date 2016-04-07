using System.Collections.Generic;
using System.Linq;
using LetsCreatePokemon.Services.World.EventSwitches;

namespace LetsCreatePokemon.World
{
    internal class WorldObject : IComponentOwner
    {
        private readonly IEventSwitchPriority eventSwitchPriority;
        private readonly Dictionary<int, IList<IComponent>> componentsByEventSwitchId;  
        public string Id { get; }

        public WorldObject(string id, IEventSwitchPriority eventSwitchPriority)
        {
            this.eventSwitchPriority = eventSwitchPriority;
            componentsByEventSwitchId = new Dictionary<int, IList<IComponent>>()
            {
                [EventSwitchHandler.DefaultEventSwitchId] = new List<IComponent>()
            };
            Id = id;
        }

        public void AddComponent(Component component)
        {
            if (component != null)
            {
                componentsByEventSwitchId[EventSwitchHandler.DefaultEventSwitchId].Add(component);
            }
        }

        public void AddComponent(Component component, int eventSwitchId)
        {
            if (component != null)
            {
                if(!componentsByEventSwitchId.ContainsKey(eventSwitchId))
                    componentsByEventSwitchId.Add(eventSwitchId, new List<IComponent>());
                componentsByEventSwitchId[eventSwitchId].Add(component);
            }
        }

        public T GetComponent<T>() where T : IComponent
        {
            var component = GetComponentsFromPrioritizedEventSwitches().FirstOrDefault(c => c.GetType() == typeof (T));
            return (T) component;
        }

        public List<T> GetComponents<T>() where T : IComponent
        {
            return GetComponentsFromPrioritizedEventSwitches().Where(c => c is T).Cast<T>().ToList(); 
        }

        private IList<IComponent> GetComponentsFromPrioritizedEventSwitches()
        {
            var eventSwitchIdes = eventSwitchPriority.GetPrioritizedEventIds(componentsByEventSwitchId.Keys.ToList()); 
            var components = new List<IComponent>();
            foreach (var eventSwitchId in eventSwitchIdes)
            {
                components.AddRange(componentsByEventSwitchId[eventSwitchId]);
            }
            return components;
        } 
    }
}
