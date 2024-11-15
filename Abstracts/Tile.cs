using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Tile
    {
        private Texture2D _texture;
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public static int WIDTH = 4;
        public static int HEIGHT = 4;

        public Tile(GraphicsDevice graphicsDevice, int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
            
            _texture = new Texture2D(graphicsDevice, 1, 1);
            _texture.SetData(new[] { Color });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(X, Y, WIDTH, HEIGHT), Color);
        }
    }
}