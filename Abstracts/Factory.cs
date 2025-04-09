namespace Abstracts
{
    public static class Factory
    {
        private const int Origin = 8;
        private const int Width = 1096;
        private const int Height = 968;

        public static Cell Instantiate(int x, int y)
        {
            if (x == Origin)
            {
                if (y == Origin) return new TopLeft(x, y);
                if (y == Height) return new BottomLeft(x, y);
                return new Left(x, y);
            }

            if (x == Width)
            {
                if (y == Origin) return new TopRight(x, y);
                if (y == Height) return new BottomRight(x, y);
                return new Right(x, y);
            }

            if (y == Origin) return new Top(x, y);
            if (y == Height) return new Bottom(x, y);
            return new Inner(x, y);
        }
    }
}