using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Editor : Illustrator
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;

        public Editor(GraphicsDevice graphicsDevice)
        {
            _texture = new Texture2D(graphicsDevice, 1, 1);
            _texture.SetData(new[] { Color.White });
            _spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void Vectorize(Grid grid)
        {
            _spriteBatch.Begin();
            for (int i = 0; i < grid.Width; i++)
            {
                for (int j = 0; j < grid.Height; j++)
                {
                    Cell cell  = grid.Get(i, j);
                    foreach (Tile tile in cell.Tiles)
                    {
                        SingleTile(tile.X, tile.Y, Color.DarkGoldenrod);
                    }
                }
            }
            
            _spriteBatch.End();
        }

        private void SingleTile(int x, int y, Color color)
        {
            Tile tile = new Tile(x, y);
            _spriteBatch.Draw(_texture, new Rectangle(tile.X, tile.Y, Tile.WIDTH, Tile.HEIGHT), color);
        }
    }
}