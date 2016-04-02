using System.Collections.Generic;
using LetsCreatePokemon.EventArg;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.World.Emotions;
using LetsCreatePokemon.World.Events;

namespace LetsCreatePokemon.World.Components
{
    internal class ComponentTest : Component, IUpdateComponent
    {
        private readonly IEventRunner eventRunner;
        private readonly Input input;

        public ComponentTest(IComponentOwner owner, IEventRunner eventRunner, Input input) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.input = input;
            input.NewInput += InputOnNewInput;
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (newInputEventArgs.Inputs == Common.Inputs.A)
            {
                eventRunner.RunEvents(new List<IEvent> { new EventEmotion("player", new EmotionTrainer())});
            }
        }

        public void Update(double gameTime)
        {
            input.Update(gameTime);
        }
    }
}
