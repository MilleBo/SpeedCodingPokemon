using System.Collections.Generic;
using System.Linq;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Screens;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.World;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Screens
{
    internal class ScreenWorld : Screen, IWorldData
    {
        private readonly ITileLoader tileLoader;
        private readonly IEntityLoader entityLoader;
        private readonly EventRunner eventRunner;
        private readonly List<WorldObject> worldObjects;  

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ScreenWorld(IScreenLoader screenLoader, ITileLoader tileLoader, IEntityLoader entityLoader, EventRunner eventRunner) : base(screenLoader)
        {
            this.tileLoader = tileLoader;
            this.entityLoader = entityLoader;
            this.eventRunner = eventRunner;
            worldObjects = new List<WorldObject>();
        }

        public WorldObject GetWorldObject(string id)
        {
            return worldObjects.FirstOrDefault(w => w.Id == id);
        }

        public List<T> GetComponents<T>() where T : IComponent
        {
            var components = new List<T>();
            foreach (var worldObject in worldObjects)
            {
                components.AddRange(worldObject.GetComponents<T>());
            }
            return components; 
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            worldObjects.AddRange(tileLoader.LoadTiles(""));
            worldObjects.AddRange(entityLoader.LoadEntities("", this, eventRunner));
            GetComponents<ILoadContentComponent>().ForEach(c => c.LoadContent(contentLoader));
            eventRunner.LoadContent(this);
        }

        public override void Update(double gameTime)
        {
            GetComponents<IUpdateComponent>().ForEach(c => c.Update(gameTime));
            eventRunner.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GetComponents<IDrawComponent>().ForEach(c => c.Draw(spriteBatch));
            eventRunner.Draw(spriteBatch);
        }


    }
}
