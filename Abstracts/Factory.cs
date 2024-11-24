using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public static class Factory
    {
        public static Cell Instantiate(GraphicsDevice graphicsDevice, Vector2 position)
        {
            if (position.X == 0)
            {
                if (position.Y == 0) return new TopLeft(graphicsDevice, position, Color.Red);
                if (position.Y == 15) return new BottomLeft(graphicsDevice, position, Color.Green);
                return new Left(graphicsDevice, position, Color.Yellow);
            }

            if (position.X == 17)
            {
                if (position.Y == 0) return new TopRight(graphicsDevice, position, Color.Red);
                if (position.Y == 15) return new BottomRight(graphicsDevice, position, Color.Green);
                return new Right(graphicsDevice, position, Color.Pink);
            }

            if (position.Y == 0) return new Top(graphicsDevice, position, Color.Red);
            if (position.Y == 15) return new Bottom(graphicsDevice, position, Color.Green);
            return new Inner(graphicsDevice, position, Color.Cyan);
        }
    }
}