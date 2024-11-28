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
                        _spriteBatch.Draw(_texture, tile.square, Color.Gold);
                    }
                }
            }
            _spriteBatch.End();
        }

        public void TilePen(int x, int y, Color color)
        {
            Tile tile = new Tile(8 + x, 8 + y);
            _spriteBatch.Draw(_texture, tile.square, color);
        }
    }
}