using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Tile
    {
        private static Texture2D _texture;
        public Color Color { get; set; }
        public Rectangle Rectangle { get; set; }
        public static int WIDTH = 2;
        public static int HEIGHT = 2;

        public Tile(GraphicsDevice graphicsDevice, int x, int y, Color color)
        {
            Color = color;
            Rectangle = new Rectangle(x, y, WIDTH, HEIGHT);

            if (_texture == null)
            {
                _texture = new Texture2D(graphicsDevice, 1, 1);
                _texture.SetData(new[] { Color });
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, Color);
        }
    }
}