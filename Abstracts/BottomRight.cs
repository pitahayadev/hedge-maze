using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class BottomRight : Cell
    {
        public BottomRight(int x, int y) : base(x, y)
        {
            Walls = new Vector4(Walls.X, 1, 1, Walls.W);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Down || direction != Direction.Left;
        }
        
        public override void Open(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    Walls.X = 0;
                    break;
                case Direction.Right:
                    return;
                case Direction.Down:
                    return;
                case Direction.Left:
                    Walls.W = 0;
                    break;
            }
        }
    }
}