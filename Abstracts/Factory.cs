namespace Abstracts
{
    public static class Factory
    {
        public static Cell Instantiate(int x, int y)
        {
            int pt = 8;
            int pl = 8;
            int w = 1096;
            int h = 968;

            if (x == pl)
            {
                if (y == pt) return new TopLeft(x, y);
                if (y == h) return new BottomLeft(x, y);
                return new Left(x, y);
            }

            if (x == w)
            {
                if (y == pt) return new TopRight(x, y);
                if (y == h) return new BottomRight(x, y);
                return new Right(x, y);
            }

            if (y == pt) return new Top(x, y);
            if (y == h) return new Bottom(x, y);
            return new Inner(x, y);
        }
    }
}