using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.EventArg;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.World.Emotions;
using LetsCreatePokemon.World.Events;

namespace LetsCreatePokemon.World.Components
{
    internal class ComponentTest : Component
    {
        private readonly IEventRunner eventRunner;
        private readonly Input input;
        private readonly IReadOnlyList<Entity> entities;

        public ComponentTest(IComponentOwner owner, IEventRunner eventRunner, Input input, IReadOnlyList<Entity> entities) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.input = input;
            this.entities = entities;
            input.NewInput += InputOnNewInput;
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (newInputEventArgs.Inputs == Common.Inputs.A)
            {
                eventRunner.RunEvents(new List<IEvent> { new EventEmotion("player", entities, new EmotionTrainer())});
            }
        }

        public override void Update(double gameTime)
        {
            input.Update(gameTime);
        }
    }
}
