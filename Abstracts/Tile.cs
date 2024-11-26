using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class Tile
    {
        public Vector2 Position { get; set; }
        public static int WIDTH = 2;
        public static int HEIGHT = 2;

        public Tile(Vector2 position)
        {
            Position = position;
        }
    }
}