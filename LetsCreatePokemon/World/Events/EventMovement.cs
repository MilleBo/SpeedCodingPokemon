using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Services;
using LetsCreatePokemon.Services.Content;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.World.Components;
using LetsCreatePokemon.World.Components.Movements;
using LetsCreatePokemon.World.Pathfindings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.World.Events
{
    internal class EventMovement : IEvent
    {
        private readonly Pathfinding pathfinding; 
        private readonly string worldObjectId;
        private readonly Vector2 goalTilePosition;
        private Sprite sprite;
        private Movement movement;
        private IList<Vector2> path;
        private int index;
        public bool IsDone { get; private set; }

        public EventMovement(string worldObjectId, Vector2 goalTilePosition)
        {
            this.worldObjectId = worldObjectId;
            this.goalTilePosition = goalTilePosition;
            pathfinding = new Pathfinding();
        }

        public void Initialize(IWorldData worldData)
        {
            sprite = worldData.GetWorldObject(worldObjectId).GetComponent<Sprite>();
            movement = worldData.GetWorldObject(worldObjectId).GetComponent<Movement>();
            path = pathfinding.FindPath(sprite.TilePosition, goalTilePosition,worldData.GetComponents<ICollisionComponent>());
            index = 0;
            IsDone = false;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            
        }

        public void Update(double gameTime)
        {
            if (movement.InMovement)
            {
                return; 
            }
            GoToNextTile();
        }

        private void GoToNextTile()
        {
            if (index < path.Count)
            {
                var tile = path[index];
                var directionVector = tile - sprite.TilePosition;
                movement.Move(UtilityService.ConvertVectorToDirection(directionVector));
                index++;
            }
            else
            {
                IsDone = true; 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
