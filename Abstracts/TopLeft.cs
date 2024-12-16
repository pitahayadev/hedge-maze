using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class TopLeft : Cell
    {
        public TopLeft(int x, int y) : base(x, y)
        {
            Walls = new Vector4(1, Walls.Y, Walls.Z, 1);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Up && direction != Direction.Left;
        }
        
        public override void Open(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    break;
                case Direction.Right:
                    Walls.Y = 0;
                    break;
                case Direction.Down:
                    Walls.Z = 0;
                    break;
                case Direction.Left:
                    break;
            }
        }

        public override int Wall(int index) => base.Wall(index);
    }
}