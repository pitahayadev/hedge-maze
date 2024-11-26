using Microsoft.Xna.Framework;
using static Abstracts.IPathable;

namespace Abstracts
{
    public class TopLeft : Cell
    {
        public TopLeft(Vector2 position) : base(position)
        {
            Walls = new Vector4(1, Walls.Y, Walls.Z, 1);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Up || direction != Direction.Left;
        }
        
        public override void Open(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    return;
                case Direction.Right:
                    Walls.Y = 0;
                    break;
                case Direction.Down:
                    Walls.Z = 0;
                    break;
                case Direction.Left:
                    return;
            }
        }
    }
}