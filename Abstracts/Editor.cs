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
                        if(cell.Walls.X == 1 && tile.Y == cell.Position.Y)
                        {
                            SingleTile(tile.X, tile.Y, Color.PaleGoldenrod);
                        }
                        else if(cell.Walls.Y == 1 && tile.X == cell.Position.X + Cell.WIDTH - Tile.WIDTH)
                        {
                            SingleTile(tile.X, tile.Y, Color.PaleGoldenrod);
                        }
                        else if(cell.Walls.Z == 1 && tile.Y == cell.Position.Y + Cell.HEIGHT - Tile.HEIGHT)
                        {
                            SingleTile(tile.X, tile.Y, Color.PaleGoldenrod);
                        }
                        else if(cell.Walls.W == 1 && tile.X == cell.Position.X)
                        {
                            SingleTile(tile.X, tile.Y, Color.PaleGoldenrod);
                        }
                        else
                        {
                            SingleTile(tile.X, tile.Y, Color.DarkOliveGreen);
                        }
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