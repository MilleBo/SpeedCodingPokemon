//------------------------------------------------------
// 
// Copyright - (c) - 2016 - Mille Boström 
//
// Youtube channel - https://www.speedcoding.net
//------------------------------------------------------
using System;

namespace LetsCreatePokemon.EventArg
{
    internal class NewInputEventArgs : EventArgs
    {
        public Common.Inputs Inputs { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.EventArgs"/> class.
        /// </summary>
        public NewInputEventArgs(Common.Inputs inputs)
        {
            Inputs = inputs;
        }
    }
}
