using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Abstracts
{
    public class Cell
    {
        public Vector2 Position { get; set; }
        public Tile[,] Tiles = new Tile[3, 3];
        public static int WIDTH = Tile.WIDTH * 3;
        public static int HEIGHT = Tile.HEIGHT * 3;

        public Cell(GraphicsDevice graphicsDevice, Vector2 position)
        {
            Position = position;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int cell_id = (i * 3) + j;
                    Color color = cell_id % 2 == 1 || cell_id == 4 ? Color.SaddleBrown : Color.ForestGreen;
                    Tiles[i, j] = new Tile(graphicsDevice, (int)Position.X + i * Tile.WIDTH, (int)Position.Y + j * Tile.HEIGHT, color);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}