using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.Common;
using LetsCreatePokemon.Pokemons.Data;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon.Battle.UI
{
    abstract class PokemonStateBar
    {
        private const int BarWidth = 110;
        private const int BarHeight = 40;
        private readonly IPokemonBattleData pokemonBattleData;
        private Texture2D barTexture;
        private Texture2D genderTexture;
        private SpriteFont font;
        protected Vector2 BasePosition;

        protected PokemonStateBar(IPokemonBattleData pokemonBattleData)
        {
            this.pokemonBattleData = pokemonBattleData;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            barTexture = contentLoader.LoadTexture("Battle/Gui/PlayerStatusbox");
            font = contentLoader.LoadFont("PokemonBattleFont");
            genderTexture = pokemonBattleData.Gender == Genders.Male
                ? contentLoader.LoadTexture("Battle/Gui/MaleIcon")
                : contentLoader.LoadTexture("Battle/Gui/FemaleIcon");
        }

        public abstract void Update(double gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barTexture, new Rectangle((int)BasePosition.X , (int)BasePosition.Y, BarWidth, BarHeight), Color.White);
            spriteBatch.DrawString(font, pokemonBattleData.Name, new Vector2(BasePosition.X  + 17, BasePosition.Y + 5), Color.Gray);
            spriteBatch.Draw(genderTexture, new Vector2(BasePosition.X  + 20 + font.MeasureString(pokemonBattleData.Name).X, BasePosition.Y + 5), Color.White);
            spriteBatch.DrawString(font, $"Lv{pokemonBattleData.Level}", new Vector2(BasePosition.X + 85, BasePosition.Y + 5), Color.Gray);
        }
    }
}
