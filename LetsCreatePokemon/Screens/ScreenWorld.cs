using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Data;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.Screens;
using LetsCreatePokemon.World;
using LetsCreatePokemon.World.Components;
using LetsCreatePokemon.World.Components.Animations;
using LetsCreatePokemon.World.Components.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Screens
{
    class ScreenWorld : Screen
    {
        private Entity entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ScreenWorld(IScreenLoader screenLoader) : base(screenLoader)
        {
            entity = new Entity("MyFirstEntity");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Height = 19 * 3,
                Width = 15 * 3,
                TextureName = "NPC/main_character",
                XTilePosition = 2,
                YTilePosition = 2
            }, new Rectangle(0, 0, 16, 19)));
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard()));
            entity.AddComponent(new Animation(entity));
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            entity.LoadContent(contentLoader);
        }

        public override void Update(double gameTime)
        {
           entity.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            entity.Draw(spriteBatch);
        }
    }
}
