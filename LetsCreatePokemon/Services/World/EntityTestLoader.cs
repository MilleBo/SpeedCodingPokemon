using System.Collections.Generic;
using LetsCreatePokemon.Data;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.World;
using LetsCreatePokemon.World.Components;
using LetsCreatePokemon.World.Components.Animations;
using LetsCreatePokemon.World.Components.Movements;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Services.World
{
    internal class EntityTestLoader : IEntityLoader
    {
        public IList<Entity> LoadEntities(string mapName)
        {
            var entity = new Entity("MyFirstEntity");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Height = 19,
                Width = 15,
                TextureName = "NPC/main_character",
                XTilePosition = 2,
                YTilePosition = 2
            }, new Rectangle(0, 0, 16, 19)));
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard()));
            entity.AddComponent(new Animation(entity));
            return new List<Entity> {entity};
        }
    }
}