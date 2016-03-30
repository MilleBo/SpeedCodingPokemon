using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Events
{
    internal interface IEvent
    {
        bool IsDone { get; }
        void Initialize();
        void LoadContent(IContentLoader contentLoader);
        void Update(double gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
