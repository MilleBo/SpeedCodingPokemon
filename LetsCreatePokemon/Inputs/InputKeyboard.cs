//------------------------------------------------------
// 
// Copyright - (c) - 2016 - Mille Boström 
//
// Youtube channel - https://www.speedcoding.net
//------------------------------------------------------
using Microsoft.Xna.Framework.Input;

namespace LetsCreatePokemon.Inputs
{
    internal class InputKeyboard : Input
    {
        private KeyboardState keyboardState;
        private KeyboardState lasKeyboardState;
        private Keys lastKey;

        protected override void CheckInput(double gameTime)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyUp(lastKey) && lastKey != Keys.None)
            {
                SendNewInput(Common.Inputs.None);
            }

            CheckKeyState(Keys.Left, Common.Inputs.Left);
            CheckKeyState(Keys.Up, Common.Inputs.Up);
            CheckKeyState(Keys.Right, Common.Inputs.Right);
            CheckKeyState(Keys.Down, Common.Inputs.Down);

            lasKeyboardState = keyboardState;
        }

        private void CheckKeyState(Keys key, Common.Inputs sendInputs)
        {
            if (keyboardState.IsKeyDown(key))
            {
                SendNewInput(sendInputs);
                lastKey = key; 
            }
        }
    }
}
