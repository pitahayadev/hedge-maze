using Microsoft.Xna.Framework;

namespace Abstracts
{
    public abstract class Cell : IPathable
    {
        public Vector2 Position { get; set; }
        public Vector4 Walls;
        public Tile[,] Tiles { get; set; }
        public static int SIZE { get; set; } = 32;
        public static int WIDTH = Tile.WIDTH * SIZE;
        public static int HEIGHT = Tile.HEIGHT * SIZE;
        
        public Cell(int x, int y)
        {
            Position = new Vector2(x, y);
            Tiles = new Tile[SIZE, SIZE];
            Walls = new Vector4(1, 1, 1, 1);
            
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Tiles[i, j] = new Tile((int)Position.X + i * Tile.WIDTH, (int)Position.Y + j * Tile.HEIGHT);
                }
            }
        }

        public abstract bool Can(Direction direction);
        public abstract void Open(Direction direction);
        public virtual int Wall(int index)
        {
            return index switch
            {
                0 => (int)Walls.X,
                1 => (int)Walls.Y,
                2 => (int)Walls.Z,
                _ => (int)Walls.W
            };
        }
    }
}