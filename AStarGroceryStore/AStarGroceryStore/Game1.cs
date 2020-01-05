using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        public static MyList<Shopper> shoppers = new MyList<Shopper>();

        //public static MyList<GameObject> gameObjects = new MyList<GameObject>();
        public Baker baker;
        public Fruit fruit;
        public Butcher butcher;
        private bool drawn = false;
        public static MyList<PathNode> allPathNodes = new MyList<PathNode>();



        /*private static ContentManager _content;
        public static ContentManager ContentManager
        {
            get
            {
                return _content;
            }
        }*/

        //public static void AddGameObject(GameObject obj)
        //{
        //    gameObjects.Add(obj);
        //}
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //_content = Content;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            baker = new Baker();
            fruit = new Fruit();
            butcher = new Butcher();
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
            int n = 64;
            for (int i = 0; i < 20; i++)
            {
                for (int x = 0; x < 11; x++)
                {
                    spriteBatch.Draw(floor, new Vector2(distance, floordistance), Color.White);

                    if (!drawn)
                    {
                        PathNode myNode = new PathNode(new Vector2(distance, floordistance), 0, 0, "walkable");

                        if ((i == 2 && x == 2) || (i == 2 && x == 3) | (i == 2 && x == 4) || (i == 5 && x == 5) || (i == 7 && x == 6) || (i == 7 && x == 5) || (i == 7 && x == 4) || (i == 3 && x == 1))
                        {
                            myNode.Type = "unwalkable";
                        }

                        if (myNode.Position == fruit.position)
                        {
                            myNode.Type = "fruit";
                        }
                        else if (myNode.Position == baker.position)
                        {
                            myNode.Type = "baker";
                        }
                        else if (myNode.Position == butcher.position)
                        {
                            myNode.Type = "butcher";
                        }
                        else if (myNode.Position == new Vector2(64, 640))
                        {
                            myNode.Type = "register";
                        }
                        allPathNodes.Add(myNode);
                    }
                    if ((i == 2 && x == 2) || (i == 2 && x == 3) | (i == 2 && x == 4) || (i == 5 && x == 5) || (i == 7 && x == 6) || (i == 7 && x == 5) || (i == 7 && x == 4) || (i == 3 && x == 1))
                    {
                        spriteBatch.Draw(emtyShelfH, new Vector2(distance, floordistance), Color.White);
                    }
                    floordistance += 64;

                    
                }
                floordistance = 0;
                distance += 64;

            }

            if (!drawn)
            {
                
                shoppers.Add(new Shopper());
            }
            drawn = true;

            foreach(Shopper shopper in shoppers)
            {
                spriteBatch.Draw(player, shopper.position, Color.White);
            }

            
            spriteBatch.Draw(fruitShelf, Vector2.Zero, Color.White);
            spriteBatch.Draw(breadShelf, new Vector2(n * 10, 0), Color.White);
            spriteBatch.Draw(meatShelf, new Vector2(n * 19, 0), Color.White);
            spriteBatch.Draw(register, new Vector2(0, n * 10), Color.White);


            //for (int i = 0; i < 7; i++)
            //{
            //    spriteBatch.Draw(emtyShelfH, new Vector2(n * (19 - i), n * 2), Color.White);
            //}

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
