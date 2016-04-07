using System.Collections.Generic;
using LetsCreatePokemon.EventArg;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.Services.World.EventSwitches;
using LetsCreatePokemon.World.Emotions;
using LetsCreatePokemon.World.Events;

namespace LetsCreatePokemon.World.Components
{
    internal class ComponentTest : Component, IUpdateComponent
    {
        private readonly IEventRunner eventRunner;
        private readonly Input input;
        private readonly IEventSwitchUpdater eventSwitchUpdater;
        private bool lastUpdate; 

        public ComponentTest(IComponentOwner owner, IEventRunner eventRunner, Input input, IEventSwitchUpdater eventSwitchUpdater) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.input = input;
            this.eventSwitchUpdater = eventSwitchUpdater;
            input.NewInput += InputOnNewInput;
            lastUpdate = false; 
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (newInputEventArgs.Inputs == Common.Inputs.A)
            {
                lastUpdate = !lastUpdate;
                eventSwitchUpdater.UpdateEventSwitch(1, lastUpdate);
                //eventRunner.RunEvents(new List<IEvent> { new EventEmotion("player", new EmotionTrainer())});
            }
        }

        public void Update(double gameTime)
        {
            input.Update(gameTime);
        }
    }
}
