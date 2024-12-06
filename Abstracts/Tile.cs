namespace Abstracts
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static int WIDTH = 2;
        public static int HEIGHT = 2;

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}