﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace AStarGroceryStore
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D player;
        Texture2D floor, wall, breadShelf, meatShelf, fruitShelf;
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            Baker baker = new Baker();

            foreach(ShopItem item in baker.ShopItems)
            {
                Console.WriteLine(item.ItemType);
            }

            Fruit fruit = new Fruit();

            foreach(ShopItem item in fruit.ShopItems)
            {
                Console.WriteLine(item.ItemType);
            }

            Butcher butcher = new Butcher();

            foreach(ShopItem item in butcher.ShopItems)
            {
                Console.WriteLine(item.ItemType);
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
            player = Content.Load<Texture2D>("DerpAgent");
            floor = Content.Load<Texture2D>("floor");
            wall = Content.Load<Texture2D>("emtyShelf");
            fruitShelf = Content.Load<Texture2D>("fruitShelf");
            meatShelf = Content.Load<Texture2D>("meatShelf");
            breadShelf = Content.Load<Texture2D>("breadShelf");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            int distance = 0;
            int floordistance = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int x = 0; x < 11; x++)
                {
                    spriteBatch.Draw(floor, new Vector2(distance, floordistance), Color.White);
                    
                    floordistance += 64;
                }
                floordistance = 0;
                distance += 64;
            }

            spriteBatch.Draw(player, new Vector2(400, 400), Color.White);
            spriteBatch.Draw(fruitShelf, Vector2.Zero, Color.White);
            spriteBatch.Draw(breadShelf, new Vector2(640, 0), Color.White);
            //spriteBatch.Draw(wall, new Vector2(), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
