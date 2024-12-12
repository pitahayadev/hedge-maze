using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class Right : Cell
    {
        public Right(int x, int y) : base(x, y)
        {
            Walls = new Vector4(Walls.X, 1, Walls.Z, Walls.W);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Right;
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
                    Walls.Z = 0;
                    break;
                case Direction.Left:
                    Walls.W = 0;
                    break;
            }
        }
    }
}