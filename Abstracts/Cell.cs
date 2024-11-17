using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Cell : IDisposable
    {
        public Vector2 Position { get; set; }
        public Tile[,] Tiles { get; set; }
        public int Size { get; set; }
        public static int WIDTH = Tile.WIDTH * 24;
        public static int HEIGHT = Tile.HEIGHT * 24;
        
        public Cell(GraphicsDevice graphicsDevice, Vector2 position, int size = 24)
        {
            Position = position;
            Size = size;
            Tiles = new Tile[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Color color = Color.White;
                    Tiles[i, j] = new Tile(graphicsDevice, color, (int)Position.X + i * Tile.WIDTH, (int)Position.Y + j * Tile.HEIGHT);
                }
            }
        }
        
        public void Draw()
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw();
            }
        }
        
        public void ChangeColor(int[] tiles, Color color)
        {
            foreach (int i in tiles)
            {
                int x = i % Size;
                int y = i / Size;
                if (x >= 0 && x < Size && y >= 0 && y < Size)
                {
                    Tiles[x, y].ChangeColor(color);
                }
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Tiles[i, j].Dispose();
                }
            }
        }
    }
}