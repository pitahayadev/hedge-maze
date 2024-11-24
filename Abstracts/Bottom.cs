using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Abstracts.IPathable;

namespace Abstracts
{
    public class Bottom : Cell
    {
        public Bottom(GraphicsDevice graphicsDevice, Vector2 position, Color color) : base(graphicsDevice, position, color)
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
                    return;
                case Direction.Left:
                    Walls.W = 0;
                    break;
            }
        }
    }
}