using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class Bottom : Cell
    {
        public Bottom(int x, int y) : base(x, y)
        {
            Walls = new Vector4(Walls.X, Walls.Y, 1, Walls.W);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Down;
        }
        
        public override void Open(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    Walls.X = 0;
                    break;
                case Direction.Right:
                    Walls.Y = 0;
                    break;
                case Direction.Down:
                    break;
                case Direction.Left:
                    Walls.W = 0;
                    break;
            }
        }

        public override int Wall(int index) => base.Wall(index);
    }
}