using System.Collections.Generic;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Screens;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.World;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Screens
{
    internal class ScreenWorld : Screen
    {
        private readonly ITileLoader tileLoader;
        private readonly IEntityLoader entityLoader;
        private List<IWorldObject> worldObjects;  

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ScreenWorld(IScreenLoader screenLoader, ITileLoader tileLoader, IEntityLoader entityLoader) : base(screenLoader)
        {
            this.tileLoader = tileLoader;
            this.entityLoader = entityLoader;  
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            worldObjects = new List<IWorldObject>();
            worldObjects.AddRange(tileLoader.LoadGraphicTiles(""));
            worldObjects.AddRange(entityLoader.LoadEntities(""));
            foreach (var worldObject in worldObjects)
            {
                worldObject.LoadContent(contentLoader);
            }
        }

        public override void Update(double gameTime)
        {
            foreach (var worldObject in worldObjects)
            {
                worldObject.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var worldObject in worldObjects)
            {
                worldObject.Draw(spriteBatch);
            }
        }
    }
}
