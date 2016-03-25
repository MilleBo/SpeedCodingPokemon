using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Screens;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Screens
{
    internal abstract class Screen
    {
        protected readonly IScreenLoader ScreenLoader;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        protected Screen(IScreenLoader screenLoader)
        {
            this.ScreenLoader = screenLoader;
        }

        public abstract void LoadContent(IContentLoader contentLoader);
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
