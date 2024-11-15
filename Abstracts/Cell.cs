using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Cell
    {
        public Vector2 Position { get; set; }
        public Tile[,] Tiles { get; set; } = new Tile[12, 12];
        public static int WIDTH = Tile.WIDTH * 12;
        public static int HEIGHT = Tile.HEIGHT * 12;

        public Cell(GraphicsDevice graphicsDevice, Vector2 position)
        {
            Position = position;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    //int cell_id = (i * 12) + j;
                    Color color = Color.Azure; //cell_id % 2 == 1 || cell_id == 4 ? Color.SaddleBrown : Color.ForestGreen;
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