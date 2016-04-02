using System.Collections.Generic;
using System.Linq;

namespace LetsCreatePokemon.World
{
    internal class WorldObject : IComponentOwner
    {
        private readonly IList<IComponent> components;
        public string Id { get; }

        public WorldObject(string id)
        {
            components = new List<IComponent>();
            Id = id;
        }

        public void AddComponent(Component component)
        {
            if (component != null)
            {
                components.Add(component);
            }
        }

        public T GetComponent<T>() where T : IComponent
        {
            var component = components.FirstOrDefault(c => c.GetType() == typeof (T));
            return (T) component;
        }

        public List<T> GetComponents<T>() where T : IComponent
        {
            return components.Where(c => c is T).Cast<T>().ToList(); 
        }
    }
}
