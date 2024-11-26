using Microsoft.Xna.Framework;

namespace Abstracts
{
    public static class Factory
    {
        public static Cell Instantiate(Vector2 position)
        {
            if (position.X == 0)
            {
                if (position.Y == 0) return new TopLeft(position);
                if (position.Y == 15) return new BottomLeft(position);
                return new Left(position);
            }

            if (position.X == 17)
            {
                if (position.Y == 0) return new TopRight(position);
                if (position.Y == 15) return new BottomRight(position);
                return new Right(position);
            }

            if (position.Y == 0) return new Top(position);
            if (position.Y == 15) return new Bottom(position);
            return new Inner(position);
        }
    }
}