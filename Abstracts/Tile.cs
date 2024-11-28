using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class Tile
    {
        public Rectangle square { get; set; }
        public static int WIDTH = 2;
        public static int HEIGHT = 2;

        public Tile(int x, int y)
        {
            square = new Rectangle(x, y, WIDTH, HEIGHT);
        }
    }
}