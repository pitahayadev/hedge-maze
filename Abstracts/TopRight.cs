using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class TopRight : Cell
    {
        public TopRight(int x, int y) : base(x, y)
        {
            Walls = new Vector4(1, 1, Walls.Z, Walls.W);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Up && direction != Direction.Right;
        }
        
        public override void Open(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    break;
                case Direction.Right:
                    break;
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