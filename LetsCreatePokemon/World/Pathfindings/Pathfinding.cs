using System.Collections.Generic;
using System.Linq;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Services;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Pathfindings
{
    internal class Pathfinding
    {
        private readonly List<PathNode> openList;
        private readonly List<PathNode> closedList;
        private const int MaxDepth = 500; 

        public Pathfinding()
        {
            openList = new List<PathNode>();
            closedList = new List<PathNode>();
        }

        public IList<Vector2> FindPath(Vector2 startTilePosition, Vector2 goalTilePosition,
            IList<ICollisionComponent> collisions)
        {
            if (startTilePosition == goalTilePosition)
                return new List<Vector2>();
            openList.Clear();
            closedList.Clear();
            openList.Add(new PathNode(startTilePosition, goalTilePosition, null));
            CheckForPath(openList.First(), goalTilePosition, collisions, 0);
            var node = closedList.Last();
            var path = new List<Vector2>();
            while (node.Parent != null)
            {
                path.Add(node.TilePosition);
                node = node.Parent; 
            }
            path.Reverse();
            return path; 
        } 

        private void CheckForPath(PathNode currentNode, Vector2 goalTilePosition, IList<ICollisionComponent> collisions,
            int depth)
        {
            if (depth == MaxDepth)
                return;
            openList.Remove(currentNode);
            closedList.Add(currentNode);
            if (currentNode.TilePosition == goalTilePosition)
                return; 
            CheckNode(Directions.Up, currentNode, goalTilePosition, collisions);
            CheckNode(Directions.Right, currentNode, goalTilePosition, collisions);
            CheckNode(Directions.Down, currentNode, goalTilePosition, collisions);
            CheckNode(Directions.Left, currentNode, goalTilePosition, collisions);
            openList.Sort(new PathNodeComparer());
            if (openList.Any())
            {
                CheckForPath(openList.First(), goalTilePosition, collisions, ++depth);
            }
        }

        private void CheckNode(Directions direction, PathNode currentNode, Vector2 goalTilePosition,
            IList<ICollisionComponent> collisions)
        {
            var directionVector = UtilityService.ConvertDirectionToVector(direction);
            var newPosition = currentNode.TilePosition + directionVector;
            if (!collisions.Any(c => c.Collide(newPosition)))
            {
                var oldNode = openList.FirstOrDefault(o => o.TilePosition == newPosition);
                if (oldNode != null)
                {
                    if (currentNode.CostFromStartPosition + PathNode.TileCost < oldNode.CostFromStartPosition)
                    {
                        oldNode.Parent = currentNode;
                        oldNode.CostFromStartPosition = currentNode.CostFromStartPosition + PathNode.TileCost;
                    }
                }
                else
                {
                    openList.Add(new PathNode(newPosition, goalTilePosition, currentNode));
                }
            }
        }
    }
}
