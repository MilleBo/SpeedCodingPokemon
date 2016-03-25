using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Screens;

namespace LetsCreatePokemon.Services.Screens
{
    interface IScreenLoader
    {
        void LoadScreen(Screen screen); 
    }
}
