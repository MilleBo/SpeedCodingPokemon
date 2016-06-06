using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreatePokemon.Battle.Common.PokeBallEnterAnimations
{
    internal class NoPokeBallEnterAnimation : IPokeBallEnterAnimation
    {
        public bool IsDone { get; set; }

        public void Update(double gameTime, PokeBallData pokeBallData)
        {
            IsDone = true; 
        }
    }
}
