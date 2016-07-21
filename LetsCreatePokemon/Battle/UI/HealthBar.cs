using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.UI
{
    class HealthBar
    {
        private int currentHealth;
        private int maxHealth;
        private enum HealthState
        {
            Normal,
            Low,
            Critical
        };

        private HealthState currentHealthState;
        private Texture2D texture;
        private int wantedHealth;
        private int barWidth; 

        public HealthBar(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
            wantedHealth = currentHealth;
            UpdateHealthState();
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture("Battle/Gui/HealthBar");
        }

        public void UpdateHealth(int currentHealth, int maxHealth)
        {
            wantedHealth = currentHealth;
            this.maxHealth = maxHealth;
        }

        public void UpdateHealthState()
        {
            var percent = (float) currentHealth/(float) maxHealth;
            if (percent < 0.2)
            {
                currentHealthState = HealthState.Critical;
            }
            else if (percent < 0.5)
            {
                currentHealthState = HealthState.Low;
            }
            else
            {
                currentHealthState = HealthState.Normal;
            }
            barWidth = (int)(((float)currentHealth / maxHealth) * 50);
        }

        public void Update()
        {
            if (wantedHealth == currentHealth) return;

            if (wantedHealth < currentHealth)
            {
                currentHealth--;
            }
            if (wantedHealth > currentHealth)
            {
                currentHealth++;
            }
            UpdateHealthState();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X + 51, (int)position.Y + 18, barWidth, 4), new Rectangle(0, 3 * (int)currentHealthState, 1, 3), Color.White);
        }

    }
}
