using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public IList<Entity> LoadEntities(string mapName, IList<ICollisionObject> collisionObjects, IEventRunner eventRunner)
        {
            var entityList = new List<Entity>();
            var readonlyEntityList = new ReadOnlyCollection<Entity>(entityList);
            var entity = new Entity("player");
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
            entity.AddComponent(new Collision(entity, new ReadOnlyCollection<ICollisionObject>(collisionObjects)));
            entity.AddComponent(new ComponentTest(entity, eventRunner, new InputKeyboard(), readonlyEntityList));
            //NPC
            var entityNpc = new Entity("npc");
            entityNpc.AddComponent(new Sprite(entityNpc, new SpriteData
            {
                Color = Color.White,
                Height = 19,
                Width = 15,
                TextureName = "NPC/rock_trainer",
                XTilePosition = 4,
                YTilePosition = 4
            }, new Rectangle(0, 0, 16, 19)));
            entityNpc.AddComponent(new Animation(entityNpc, new AnimationSpinning(16, 20, 400)));
            entityList.Add(entityNpc);
            entityList.Add(entity);
            return entityList;
        }
    }
}