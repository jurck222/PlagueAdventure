using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlagueAdventure
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D targetSprite;
        Texture2D player;
        Texture2D background;
        Texture2D rat;
        Texture2D environment;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player = Content.Load<Texture2D>("Player");
            rat = Content.Load<Texture2D>("rat_enemy");
            background = Content.Load<Texture2D>("Area");
            environment = Content.Load<Texture2D>("environment_objects");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Rectangle playerRect = new Rectangle(0, 250, 200, 500);
            Rectangle feet = new Rectangle(0, 150, 200, 100);
            Rectangle back = new Rectangle(0, 0, 2000, 2000);
            Rectangle lamp = new Rectangle(250,0, 125, 250);
            Rectangle spike = new Rectangle(0, 400, 125, 100);
            Rectangle tree = new Rectangle(125, 250, 125, 250);
            Rectangle strasilo = new Rectangle(375, 125, 75, 125);
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(1000, 0),back, Color.White,1.57f,
                new Vector2(0, 0),
                2f,
                SpriteEffects.None,
                0);
            _spriteBatch.Draw(player,
                new Vector2(275, 120),
                playerRect,
                Color.White,
                1.57f,
                new Vector2(0, 0),
                1f,
                SpriteEffects.None,
                0);
            _spriteBatch.Draw(
                player,
                new Vector2(150, 120), 
                feet, 
                Color.White,
                1.57f,
                new Vector2(0,0),
                1f,
                SpriteEffects.None,
                0);
            _spriteBatch.Draw(environment,
                new Vector2(670, 1600),
                lamp,
                Color.White,
                1.57f,
                new Vector2(0, 0),
                1.5f,
                SpriteEffects.FlipHorizontally,
                0);
            _spriteBatch.Draw(environment,
                new Vector2(250, 800),
                spike,
                Color.White,
                1.57f,
                new Vector2(0, 0),
                1f,
                SpriteEffects.FlipHorizontally,
                0);
            _spriteBatch.Draw(environment,
               new Vector2(710, 1200),
               tree,
               Color.White,
               1.57f,
               new Vector2(0, 0),
               2f,
               SpriteEffects.FlipHorizontally,
               0);
            _spriteBatch.Draw(environment,
               new Vector2(520, 1800),
               strasilo,
               Color.White,
               1.57f,
               new Vector2(0, 0),
               1.7f,
               SpriteEffects.FlipHorizontally,
               0);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}