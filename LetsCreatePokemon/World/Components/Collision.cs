using System.Linq;
using LetsCreatePokemon.Services.World;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Components
{
    internal class Collision : Component, ICollisionComponent
    {
        private readonly IWorldData worldData;

        public Collision(IComponentOwner owner, IWorldData worldData) : base(owner)
        {
            this.worldData = worldData;
        }

        public bool CheckCollision(int xTilePosition, int yTilePosition)
        {
            var collisionObjects = worldData.GetComponents<ICollisionComponent>();
            return collisionObjects.Any(c => c.Collide(xTilePosition, yTilePosition));
        }

        public bool Collide(int xTilePosition, int yTilePosition)
        {
            var sprite = Owner.GetComponent<Sprite>();
            if (sprite == null)
                return false;
            return sprite.TilePosition == new Vector2(xTilePosition, yTilePosition);
        }
    }
}
