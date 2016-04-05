using System.Collections.Generic;
using System.Collections.ObjectModel;
using LetsCreatePokemon.Data;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.World;
using LetsCreatePokemon.World.Components;
using LetsCreatePokemon.World.Components.Animations;
using LetsCreatePokemon.World.Components.Movements;
using LetsCreatePokemon.World.Emotions;
using LetsCreatePokemon.World.Events;
using LetsCreatePokemon.World.EventTriggers;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Services.World
{
    internal class EntityTestLoader : IEntityLoader
    {
        public IList<WorldObject> LoadEntities(string mapName, IWorldData worldData, IEventRunner eventRunner)
        {
            var entityList = new List<WorldObject>();
            var entity = new WorldObject("player");
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
            entity.AddComponent(new Collision(entity, worldData));
            entity.AddComponent(new ComponentTest(entity, eventRunner, new InputKeyboard()));
            //NPC
            var entityNpc = new WorldObject("npc");
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
            entityNpc.AddComponent(new Collision(entityNpc,worldData));
            entityNpc.AddComponent(new EventTriggerEyeContact(entityNpc, eventRunner, new List<IEvent> { new EventEmotion("npc", new EmotionTrainer()), new EventMovement("npc", new Vector2(8, 8))}, worldData));
            entityNpc.AddComponent(new Movement(entityNpc, 1));
            entityList.Add(entityNpc);
            entityList.Add(entity);
            return entityList;
        }
    }
}