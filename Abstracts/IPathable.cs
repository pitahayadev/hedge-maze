namespace Abstracts
{
    public interface IPathable
    {
        enum Direction
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }
        bool Can(Direction direction);
        void Open(Direction direction);
    }
}