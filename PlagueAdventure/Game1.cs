using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using PlagueAdventure.menus;
using PlagueAdventure.Source;
using PlagueAdventure.Source.Engine;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;

namespace PlagueAdventure
{ 
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SaveManager saveManager;
        public static int ScreenHeight;
        public static int ScreenWidth;
        Basic2d player;
        World world;
        Menu menu;
        Settings settings;

        public static Camera camera;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            saveManager = SaveManager.load();
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals._spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.touchState = new TouchCollection();
            saveManager = SaveManager.load();
            
            player = new Basic2d("Player", new Vector2((ScreenHeight/2)-256/2, (ScreenWidth / 2) - 165 / 2), 25, 256, 165, 219, 1f);
            world = new World();
            menu = new Menu();
            settings = new Settings();
            
            
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Globals.start)
            {
                Globals.gameTime = gameTime;
                if (Globals.reset)
                {
                    world = new World();
                    Globals.hero_health = 100;
                    Globals.score = 0;
                    Globals.reset = false;
                    
                }
                world.Update(gameTime);
            }
            else if (Globals.menu)
            {
                menu.Update(gameTime,this,saveManager);
                camera.Follow(player);
            }
            else if (Globals.settings) {
                settings.Update(gameTime,this);
            }
            
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            Globals._spriteBatch.Begin(transformMatrix: camera.Transform);
            
            if (Globals.start)
            {
                world.Draw(Vector2.Zero, gameTime);
            }
            else if (Globals.menu)
            {
                menu.Draw(Vector2.Zero, gameTime);
            }
            else if (Globals.settings) {
                settings.Draw(Vector2.Zero, gameTime);
            }
            Globals._spriteBatch.End();
            base.Draw(gameTime);
        }
        public void Quit()
        {
            this.Exit();
        }
    }
}