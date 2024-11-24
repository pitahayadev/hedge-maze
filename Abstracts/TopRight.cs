using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Abstracts.IPathable;

namespace Abstracts
{
    public class TopRight : Cell
    {
        public TopRight(GraphicsDevice graphicsDevice, Vector2 position, Color color) : base(graphicsDevice, position, color)
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