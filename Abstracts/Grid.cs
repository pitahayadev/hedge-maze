using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Grid
    {
        private GraphicsDevice graphicsDevice;
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells { get; set; }

        
        public Grid(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            this.Width = 18; //graphicsDevice.Viewport.Width / Cell.WIDTH;
            this.Height = 16; //graphicsDevice.Viewport.Height / Cell.HEIGHT;
            this.Cells = new Cell[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    // with walls: V2(i + i * Cell.WIDTH, j + j * Cell.HEIGHT);
                    Vector2 position = new Vector2(i+8 + i * Cell.WIDTH, j+8 + j * Cell.HEIGHT);
                    Cells[i, j] = new Cell(graphicsDevice, position);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cell cell in Cells)
            {
                cell.Draw(spriteBatch);
            }
        }
    }
}