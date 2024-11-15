using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells { get; set; }

        public Grid(GraphicsDevice graphicsDevice, int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[Width, Height];
            
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    // int index = (i * Width) + j;
                    // without walls: (8 + i * Cell.WIDTH, 8 + j * Cell.HEIGHT)
                    Vector2 position = new Vector2(i + 8 + i * Cell.WIDTH, j + 8 + j * Cell.HEIGHT);
                    Cells[i, j] = new Cell(graphicsDevice, position);
                }
            }
            /* Cells[(int)_entry.X, (int)_entry.Y].ChangeColor(Color.Black);
            Cells[(int)_exit.X, (int)_exit.Y].ChangeColor(Color.Gray); */
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