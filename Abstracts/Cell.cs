using Microsoft.Xna.Framework;
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
        
        public Cell(Vector2 position)
        {
            Position = position;
            Walls = new Vector4(1, 1, 1, 1);
            Tiles = new Tile[SIZE, SIZE];
            
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    int x = (int)Position.X + i * Tile.WIDTH;
                    int y = (int)Position.Y + j * Tile.HEIGHT;
                    Tiles[x, y] = new Tile(new Vector2(x, y));
                }
            }
        }
        public abstract bool Can(Direction direction);
        public abstract void Open(Direction direction);
    }
}