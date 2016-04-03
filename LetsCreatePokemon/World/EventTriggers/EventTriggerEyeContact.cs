using System.Collections.Generic;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Services;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.World.Components;
using LetsCreatePokemon.World.Events;

namespace LetsCreatePokemon.World.EventTriggers
{
    internal class EventTriggerEyeContact : EventTrigger
    {
        private const int Range = 4;
        private readonly IWorldData worldData;

        public EventTriggerEyeContact(IComponentOwner owner, IEventRunner eventRunner, IList<IEvent> events, IWorldData worldData) : base(owner, eventRunner, events)
        {
            this.worldData = worldData;
        }

        protected override bool ShouldTriggerEvents()
        {
            var sprite = Owner.GetComponent<Sprite>();
            var playerSprite = worldData.GetWorldObject("player").GetComponent<Sprite>();
            var currentDirection = (Directions) (sprite.DrawFrame.Y/sprite.DrawFrame.Height);
            var currentDirectionVector = UtilityService.ConvertDirectionToVector(currentDirection);
            for (int n = 0; n < Range; n++)
            {
                var position = sprite.TilePosition + currentDirectionVector*(n + 1);
                if (playerSprite.TilePosition == position)
                    return true;
                var collision = Owner.GetComponent<Collision>();
                if (collision.CheckCollision((int) position.X, (int) position.Y))
                    return false; 
            }
            return false; 
        }
    }
}
