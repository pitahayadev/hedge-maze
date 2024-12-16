using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class Inner : Cell
    {
        public Inner(int x, int y) : base(x, y)
        {
            Walls = new Vector4(Walls.X, Walls.Y, Walls.Z, Walls.W);
        }

        public override bool Can(Direction direction) => true;

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
                    Walls.Z = 0;
                    break;
                case Direction.Left:
                    Walls.W = 0;
                    break;
            }
        }

        public override int Wall(int index) => base.Wall(index);
    }
}