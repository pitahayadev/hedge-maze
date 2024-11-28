namespace Abstracts
{
    public static class Factory
    {
        public static Cell Instantiate(int x, int y)
        {
            if (x == 0)
            {
                if (y == 0) return new TopLeft(x, y);
                if (y == 15) return new BottomLeft(x, y);
                return new Left(x, y);
            }

            if (x == 17)
            {
                if (y == 0) return new TopRight(x, y);
                if (y == 15) return new BottomRight(x, y);
                return new Right(x, y);
            }

            if (y == 0) return new Top(x, y);
            if (y == 15) return new Bottom(x, y);
            return new Inner(x, y);
        }
    }
}