using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D knight;
        private Vector2 knightPosition;
        private float knightSpeed = 0f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            knightPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            knightSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            knight = Content.Load<Texture2D>("Knight");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                knightPosition.Y -= knightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                knightPosition.Y += knightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                knightPosition.X -= knightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                knightPosition.X += knightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here


            _spriteBatch.Begin();
            //_spriteBatch.Draw(knight, new Vector2(100.0f, 100.0f), Color.White);
            _spriteBatch.Draw(knight, knightPosition, null, Color.White, 0f, new Vector2(knight.Width /2, knight.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}