using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Inputs;
using Microsoft.Xna.Framework;

namespace LetsCreatePokemon.Services.Windows.Message
{
    internal class WindowBattleMessage : WindowMessage
    {
        public WindowBattleMessage(string text, Input input) : base(new Vector2(0, 113), 240, 45, text, input)
        {
            Color = Color.Transparent;
            FontColor = Color.White;
        }
    }
}
