using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreatePokemon.Screens.ScreenTransitionEffects
{
    internal class ScreenTransitionEffectFadeIn : ScreenTransitionEffectFade
    {
        public ScreenTransitionEffectFadeIn(int screenWidth, int screenHeight, byte fadeStepCount) : base(screenWidth, screenHeight, fadeStepCount)
        {
        }

        public override void Start()
        {
            Alpha = 255;
            IsDone = false;
        }

        public override void Update(double gameTime)
        {
            Alpha -= FadeStepCount;
            if (Math.Abs(Alpha) < 1)
                IsDone = true; 
        }
    }
}
