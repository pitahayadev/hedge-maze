using Microsoft.Xna.Framework;
using static Abstracts.IPathable;

namespace Abstracts
{
    public class TopRight : Cell
    {
        public TopRight(Vector2 position) : base(position)
        {
            Walls = new Vector4(1, 1, Walls.Z, Walls.W);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Up || direction != Direction.Right;
        }
        
        public override void Open(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    return;
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