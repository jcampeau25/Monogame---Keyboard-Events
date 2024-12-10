using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame___Keyboard_Events
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D pacTexture, pacRightTexture, pacLeftTexture, pacUpTexture, pacDownTexture, pacSleepTexture;
        Rectangle pacRect;
        Vector2 pacSpeed;

        KeyboardState keyboardState;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            pacRect = new Rectangle(10, 10, 75, 75);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pacRightTexture = Content.Load<Texture2D>("PacRight");
            pacLeftTexture = Content.Load<Texture2D>("PacLeft");
            pacUpTexture = Content.Load<Texture2D>("PacUp");
            pacDownTexture = Content.Load<Texture2D>("PacDown");
            pacSleepTexture = Content.Load<Texture2D>("PacSleep");

            pacSpeed = new Vector2();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            pacSpeed = Vector2.Zero;
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacSpeed.Y -= 5;
                pacTexture = pacUpTexture;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacSpeed.Y += 5;
                pacTexture = pacDownTexture;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacSpeed.X += 5;
                pacTexture = pacRightTexture;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacSpeed.X -= 5;
                pacTexture = pacLeftTexture;
            }

            if (!keyboardState.IsKeyDown(Keys.Up) && !keyboardState.IsKeyDown(Keys.Right) && !keyboardState.IsKeyDown(Keys.Left) && !keyboardState.IsKeyDown(Keys.Down))
            {
                pacTexture = pacSleepTexture;
            }

            // TODO: Add your update logic here


            pacRect.X += (int)pacSpeed.X;
            pacRect.Y += (int)pacSpeed.Y;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(pacTexture, pacRect, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
