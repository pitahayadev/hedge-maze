using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Tile
    {
        private Texture2D texture;
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public static int WIDTH = 16;
        public static int HEIGHT = 16;
        
        public Tile(GraphicsDevice graphicsDevice, int X, int Y, Color Color)
        {
            this.X = X;
            this.Y = Y;
            this.Color = Color;
            this.texture = new Texture2D(graphicsDevice, 1, 1);
            
            texture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(X, Y, Tile.WIDTH, Tile.HEIGHT), Color);
        }

        public void ChangeColor(Color color)
        {
            texture.SetData(new[] { color });
        }
    }
}