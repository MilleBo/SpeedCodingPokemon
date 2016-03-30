using System;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.EventArg;
using LetsCreatePokemon.Inputs;

namespace LetsCreatePokemon.World.Components.Movements
{
    internal class MovementPlayer : Movement
    {
        private readonly Input input;

        public MovementPlayer(IComponentOwner owner, float speed, Input input) : base(owner, speed)
        {
            this.input = input;
            this.input.NewInput += OnNewInput;
        }

        private void OnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (InMovement)
                return; 
            switch (newInputEventArgs.Inputs)
            {
                case Common.Inputs.Left:
                    Move(Directions.Left);
                    break;
                case Common.Inputs.Up:
                    Move(Directions.Up);
                    break;
                case Common.Inputs.Right:
                    Move(Directions.Right);
                    break;
                case Common.Inputs.Down:
                    Move(Directions.Down);
                    break;
                case Common.Inputs.None:
                    break;
                case Common.Inputs.A:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Update(double gameTime)
        {
            input.Update(gameTime);
            base.Update(gameTime);
        }
    }
}
