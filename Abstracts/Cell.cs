using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Abstracts
{
    public class Cell
    {
        public ICollection<Tile> List { get; set; }
        private GraphicsDevice graphicsDevice;
        public static int PADDING = 16;

        public Cell(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            List = new List<Tile>();
            int t = 0;
            int x = 0;
            int y = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    x = i % 3;
                    y = j % 3;
                    Color color = t % 2 == 1 || t == 4 ? Color.SaddleBrown : Color.ForestGreen;
                    Tile tile = new Tile(graphicsDevice, Cell.PADDING + x * Tile.WIDTH, Cell.PADDING + y * Tile.HEIGHT, color);
                    List.Add(tile);
                    t++;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in List)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}