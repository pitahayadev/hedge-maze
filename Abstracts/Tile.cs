using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static int WIDTH = 16;
        public static int HEIGHT = 16;
        public Color Color { get; set; }
        private Texture2D texture;
        
        public Tile(GraphicsDevice graphicsDevice, int X, int Y, Color Color)
        {
            this.X = X;
            this.Y = Y;
            this.Color = Color;
            texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(X, Y, Tile.WIDTH, Tile.HEIGHT), Color);
        }
    }
}