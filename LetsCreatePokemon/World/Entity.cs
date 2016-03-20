using System.Collections.Generic;
using System.Linq;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World
{
    internal class Entity : IComponentOwner
    {
        private readonly IList<Component> components;
        public string Id { get; }

        public Entity(string id)
        {
            components = new List<Component>();
            Id = id;
        }

        public void AddComponent(Component component)
        {
            if (component != null)
            {
                components.Add(component);
            }
        }

        public T GetComponent<T>() where T : Component
        {
            var component = components.FirstOrDefault(c => c.GetType() == typeof (T));
            return (T) component;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            foreach (var component in components)
            {
                component.LoadContent(contentLoader);
            }
        }

        public void Update(double gameTime)
        {
            var index = 0;
            while (index < components.Count)
            {
                if (components[index].Killed)
                {
                    components.RemoveAt(index);
                }
                else
                {
                    components[index].Update(gameTime);
                    index++; 
                }                 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in components)
            {
                component.Draw(spriteBatch);
            }
        }


    }
}
