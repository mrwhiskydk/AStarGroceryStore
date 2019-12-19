using Microsoft.Xna.Framework;
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
        Texture2D floor, emtyShelfH, emtyShelfV, breadShelf, meatShelf, fruitShelf, register;

        MyList<PathNode> allPathNodes = new MyList<PathNode>();
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
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

            MyStack<int> myStack = new MyStack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);

            foreach (var item in myStack)
            {
                System.Console.WriteLine(item);
            }

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
            emtyShelfV = Content.Load<Texture2D>("emtyShelfV");
            emtyShelfH = Content.Load<Texture2D>("emtyShelfH");
            fruitShelf = Content.Load<Texture2D>("fruitShelf");
            meatShelf = Content.Load<Texture2D>("meatShelf");
            breadShelf = Content.Load<Texture2D>("breadShelf");
            register = Content.Load<Texture2D>("register");

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
                    allPathNodes.Add(new PathNode(new Vector2(distance, floordistance), 0, 0));
                    floordistance += 64;
                }
                floordistance = 0;
                distance += 64;
            }
            int n = 64;
            spriteBatch.Draw(player, new Vector2(n * 18, n * 10), Color.White);
            spriteBatch.Draw(fruitShelf, Vector2.Zero, Color.White);
            spriteBatch.Draw(breadShelf, new Vector2(n*10, 0), Color.White);
            spriteBatch.Draw(meatShelf, new Vector2(n*19, 0), Color.White);
            spriteBatch.Draw(register, new Vector2(0, n*10), Color.White);

            for (int i = 0; i < 7; i++)
            {
                spriteBatch.Draw(emtyShelfH, new Vector2(n * (19 - i), n*2), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
