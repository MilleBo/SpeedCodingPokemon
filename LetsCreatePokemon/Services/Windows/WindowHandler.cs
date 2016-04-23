using System;
using System.Collections.Generic;
using System.Linq;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Services.Windows
{
    internal class WindowHandler : IWindowQueuer
    {
        private readonly IContentLoader contentLoader;
        private readonly Queue<Window> windows;
        private Window currentWindow;

        public bool WindowActive => windows.Any() || currentWindow != null; 

        public WindowHandler(IContentLoader contentLoader)
        {
            this.contentLoader = contentLoader; 
            windows = new Queue<Window>();
        }

        public void QueueWindow(Window window)
        {
            windows.Enqueue(window);
            ShowNextWindow(); 
        }

        private void ShowNextWindow()
        {
            if (!windows.Any() || currentWindow != null)
                return;
            currentWindow = windows.Dequeue(); 
            currentWindow.LoadContent(contentLoader);
        }

        public void Update(double gameTime)
        {
            if (currentWindow == null)
                return;
             currentWindow.Update(gameTime);
            if (currentWindow.IsDone)
            {
                currentWindow = null; 
                ShowNextWindow();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentWindow?.Draw(spriteBatch);
        }
    }
}
