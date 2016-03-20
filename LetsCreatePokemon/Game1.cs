//------------------------------------------------------
// 
// Copyright - (c) - 2016 - Mille Boström 
//
// Youtube channel - https://www.speedcoding.net
//------------------------------------------------------
using System;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreatePokemon
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Texture2D textureNotFound;
        SpriteFont font;
        InputKeyboard inputKeyboard;
        Vector2 spritePosition;
        IContentLoader contentLoader;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            inputKeyboard = new InputKeyboard();
            inputKeyboard.NewInput += InputKeyboard_NewInput;
            Content.RootDirectory = "Content";
            spritePosition = new Vector2(100, 100);
        }

        private void InputKeyboard_NewInput(object sender, EventArg.NewInputEventArgs e)
        {
            switch (e.Inputs)
            {
                case Common.Inputs.Left:
                    spritePosition.X--;
                    break;
                case Common.Inputs.Up:
                    spritePosition.Y--;
                    break;
                case Common.Inputs.Right:
                    spritePosition.X++;
                    break;
                case Common.Inputs.Down:
                    spritePosition.Y++;
                    break;
                case Common.Inputs.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            contentLoader = new ContentLoader(Content);
            texture = contentLoader.LoadTexture("NPC/main_character_single");
            textureNotFound = contentLoader.LoadTexture("textureDoesNotExist");
            font = contentLoader.LoadFont("NotFoundFont");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            inputKeyboard.Update(gameTime.ElapsedGameTime.Milliseconds);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle((int) spritePosition.X, (int) spritePosition.Y, 42, 57), Color.White);
            spriteBatch.Draw(textureNotFound, new Rectangle(300, 300, 100, 100), Color.White);
            spriteBatch.DrawString(font, "My text", new Vector2(420, 420), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
