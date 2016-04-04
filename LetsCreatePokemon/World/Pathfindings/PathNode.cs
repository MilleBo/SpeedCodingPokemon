using System;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.World.Pathfindings
{
    internal class PathNode
    {
        public const int TileCost = 10; 
        public PathNode Parent { get; set; }
        public float CostFromStartPosition { get; set; }
        public float CostToGoalPosition { get; set; }
        public float TotalCostOfNode => CostFromStartPosition*CostToGoalPosition;
        public Vector2 TilePosition { get; set; }

        public PathNode(Vector2 tilePosition, Vector2 goaltilePosition, PathNode parent)
        {
            TilePosition = tilePosition;
            Parent = parent;
            var distanceX = Math.Abs(tilePosition.X - goaltilePosition.X);
            var distanceY = Math.Abs(tilePosition.Y - goaltilePosition.Y);
            CostToGoalPosition = (distanceX + distanceY)*TileCost;
            CostFromStartPosition = TileCost;
            if (parent != null)
            {
                CostFromStartPosition += parent.CostFromStartPosition;
            }
        }
    }
}
