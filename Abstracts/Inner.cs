using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Abstracts.IPathable;

namespace Abstracts
{
    public class Inner : Cell
    {
        public Inner(GraphicsDevice graphicsDevice, Vector2 position, Color color) : base(graphicsDevice, position, color)
        {
            Walls = new Vector4(Walls.X, Walls.Y, Walls.Z, Walls.W);
        }
        
        public override bool Can(Direction direction)
        {
            return Position.X > 0 && Position.X < Cell.WIDTH && Position.Y > 0 && Position.Y < Cell.HEIGHT;
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
                    Walls.Z = 0;
                    break;
                case Direction.Left:
                    Walls.W = 0;
                    break;
            }
        }
    }
}