using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abstracts
{
    public class Tile : IDisposable
    {
        private GraphicsDevice _graphics;
        private VertexBuffer _render;
        private BasicEffect _window;
        public VertexPositionColor[] _pixels { get; }
        public static int WIDTH = 2;
        public static int HEIGHT = 2;

        public Tile(GraphicsDevice graphics, Color color, int w, int h)
        {
            _graphics = graphics;
            _pixels = new VertexPositionColor[4];
            
            for (int i = 0; i < _pixels.Length; i++)
            {
                int x = i % WIDTH;
                int y = i / WIDTH;
                _pixels[i] = new VertexPositionColor(
                    new Vector3(x + w, y + h + 1, 0),
                    color);
            }
            
            _render = new VertexBuffer(graphics,
                typeof(VertexPositionColor),
                _pixels.Length,
                BufferUsage.WriteOnly);

            _render.SetData(_pixels);
            
            _window = new BasicEffect(graphics)
            {
                VertexColorEnabled = true,
                Projection = Matrix.CreateOrthographicOffCenter(
                    0, _graphics.Viewport.Width, _graphics.Viewport.Height, 0, 0, 1)
            };
        }

        public void ChangeColor(Color color)
        {
            for (int i = 0; i < _pixels.Length; i++)
            {
                _pixels[i].Color = color;
            }
            _render.SetData(_pixels);
        }

        public void Draw()
        {
            _graphics.SetVertexBuffer(_render);
            foreach (var pass in _window.CurrentTechnique.Passes)
            {
                pass.Apply();
                _graphics.DrawPrimitives(PrimitiveType.PointList, 0, _pixels.Length);
            }
        }

        public void Dispose()
        {
            _render?.Dispose();
            _window?.Dispose();
        }
    }
}