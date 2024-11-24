using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Abstracts.IPathable;

namespace Abstracts
{
    public class Left : Cell
    {
        public Left(GraphicsDevice graphicsDevice, Vector2 position, Color color) : base(graphicsDevice, position, color)
        {
            Walls = new Vector4(Walls.X, Walls.Y, Walls.Z, 1);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Left;
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
                    return;
            }
        }
    }
}