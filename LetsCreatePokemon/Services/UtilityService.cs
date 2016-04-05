using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Common;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Services
{
    internal static class UtilityService
    {
        public static double GetDistance(Vector2 positionOne, Vector2 positionTwo)
        {
            var x = Math.Pow(positionOne.X - positionTwo.X, 2);
            var y = Math.Pow(positionOne.Y - positionTwo.Y, 2);
            return Math.Sqrt(x + y); 
        }

        public static Vector2 ConvertDirectionToVector(Directions direction)
        {
            switch (direction)
            {
                case Directions.Left:
                    return new Vector2(-1, 0);
                case Directions.Up:
                    return new Vector2(0, -1);
                case Directions.Right:
                    return new Vector2(1, 0);
                case Directions.Down:
                    return new Vector2(0, 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public static Directions ConvertVectorToDirection(Vector2 directionVector)
        {
            if(directionVector.X == -1 && directionVector.Y == 0)
                return Directions.Left;
            if (directionVector.X == 0 && directionVector.Y == -1)
                return Directions.Up;
            if (directionVector.X == 1 && directionVector.Y == 0)
                return Directions.Right;
            if (directionVector.X == 0 && directionVector.Y == 1)
                return Directions.Down;
            throw new Exception("Unable to convert direction vector to a direction");
        }
    }
}
