using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Abstracts.IPathable;

namespace Abstracts
{
    public abstract class Cell : IPathable
    {
        public Vector2 Position { get; set; }
        public Vector4 Walls;
        public Tile[,] Tiles { get; set; }
        public static Vector2[] MOVE =
        [
            new Vector2(0, -1),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(-1, 0)
        ];
        public static int SIZE { get; set; } = 24;
        public static int WIDTH = Tile.WIDTH * SIZE;
        public static int HEIGHT = Tile.HEIGHT * SIZE;
        
        public Cell(GraphicsDevice graphicsDevice, Vector2 position, Color color)
        {
            Position = position;
            Walls = new Vector4(1, 1, 1, 1);
            Tiles = new Tile[SIZE, SIZE];
            
            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                {
                    Tiles[x, y] = new Tile(graphicsDevice, (int)Position.X + x * Tile.WIDTH, (int)Position.Y + y * Tile.HEIGHT, color);
                }
            }
        }
        public abstract bool Can(Direction direction);
        public abstract void Open(Direction direction);
    }
}