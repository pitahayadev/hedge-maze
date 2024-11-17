using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Abstracts;

namespace hedge_maze
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Grid _grid;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 898,
                PreferredBackBufferHeight = 798
            };

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            // TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 30.0);
            // IsFixedTimeStep = true;
            Exiting += OnExiting;
        }

        protected override void Initialize()
        {
            _grid = new Grid(GraphicsDevice, 18, 16);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            _grid.Dispose();
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _grid.Draw();
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void OnExiting(object sender, System.EventArgs e)
        {
            _grid.Dispose();
        }
    }
}