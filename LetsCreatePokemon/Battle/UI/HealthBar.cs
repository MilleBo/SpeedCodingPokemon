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

        public HealthBar(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            wantedHealth = currentHealth;
            this.maxHealth = maxHealth;
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
            for (int n = 0; n < ((float) currentHealth/(float) maxHealth)*50; n++)
            {
                spriteBatch.Draw(texture, new Rectangle((int)position.X + 51 + n, (int)position.Y + 18, 2, 4), new Rectangle(0, 3 * (int)currentHealthState, 1, 3), Color.White);
            }
        }

    }
}
