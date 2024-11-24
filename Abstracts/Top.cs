using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Abstracts.IPathable;

namespace Abstracts
{
    public class Top : Cell
    {
        public Top(GraphicsDevice graphicsDevice, Vector2 position, Color color) : base(graphicsDevice, position, color)
        {
            Walls = new Vector4(1, Walls.Y, Walls.Z, Walls.W);
        }
        
        public override bool Can(Direction direction)
        {
            return direction != Direction.Up;
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
                    Walls.W = 0;
                    break;
            }
        }
    }
}