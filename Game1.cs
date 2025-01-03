using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Abstracts;

namespace hedge_maze
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private Grid _grid;
        private Editor _editor;
        private Maze _maze;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1168,
                PreferredBackBufferHeight = 1040
            };

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            // TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 30.0);
            // IsFixedTimeStep = true;
            Exiting += OnExiting;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _grid = new Grid(18, 16);
            _maze = new Maze(_grid);
            _maze.check();
            _editor = new Editor(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
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
            _editor.Vectorize(_grid);
            base.Draw(gameTime);
        }

        private void OnExiting(object sender, System.EventArgs e)
        {
            
        }
    }
}