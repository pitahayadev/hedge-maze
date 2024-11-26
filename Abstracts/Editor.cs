using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Editor : Illustrator
    {
        private readonly SpriteBatch _spriteBatch;

        public Editor(GraphicsDevice graphicsDevice)
        {
            _spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void Vectorize(Grid grid)
        {
            
        }
    }
}