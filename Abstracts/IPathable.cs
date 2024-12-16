namespace Abstracts
{
    public interface IPathable
    {
        bool Can(Direction direction);
        void Open(Direction direction);
        int Wall(int index);
    }
}