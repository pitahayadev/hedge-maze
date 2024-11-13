using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Grid
    {
        [Flags]
        private enum Direction
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }
        
        private int _quadrant;
        private Vector2 _entry;
        private Vector2 _exit;
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells { get; set; }

        public Grid(GraphicsDevice graphicsDevice)
        {
            this._quadrant = 0;
            this._entry = new Vector2(0, 0);
            this._exit = new Vector2(0, 0);
            this.Width = 18;
            this.Height = 16;
            this.Cells = new Cell[Width, Height];
            
            _entry = Entry();
            
            Direction h = _entry.X < Width / 2 ? Direction.Left : Direction.Right;
            Direction v = _entry.Y < Height / 2 ? Direction.Up : Direction.Down;
            _quadrant = h == Direction.Left ? (v == Direction.Up ? 1 : 3) : (v == Direction.Up ? 2 : 4);

            _exit = Exit();

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
            Cells[(int)_entry.X, (int)_entry.Y].ChangeColor(Color.Black);
            Cells[(int)_exit.X, (int)_exit.Y].ChangeColor(Color.Gray);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cell cell in Cells)
            {
                cell.Draw(spriteBatch);
            }
        }

        private Vector2 Entry()
        {
            Random random = new Random();
            int row = random.Next(0, Height);
            int col = random.Next(0, Width);
            return new Vector2(col, row);
        }

        private Vector2 Exit()
        {
            Random random = new Random();
            int row, col;
            switch (_quadrant)
            {
                case 1:
                    col = random.Next(Width / 2, Width);
                    row = random.Next(Height / 2, Height);
                    break;
                case 2:
                    col = random.Next(0, Width / 2);
                    row = random.Next(Height / 2, Height);
                    break;
                case 3:
                    col = random.Next(Width / 2, Width);
                    row = random.Next(0, Height / 2);
                    break;
                default:
                    col = random.Next(0, Width / 2);
                    row = random.Next(0, Height / 2);
                    break;
            }
            return new Vector2(col, row);
        }
    }
}