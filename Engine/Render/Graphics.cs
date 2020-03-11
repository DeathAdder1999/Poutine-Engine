using System;
using Engine.Render.Shapes;
using SFML.Graphics;
using SFML.System;

namespace Engine.Render
{
    public class Graphics
    {
        public static void Draw(ShapeBase shape)
        {
            EngineService.MainWindow.Draw(shape);
        }

        public static void DrawArrows(Vector2f pos, Vector2f scale)
        {
            var yTriangle = new Triangle(new Vector2f(0, 0), new Vector2f(10, -20), new Vector2f(20, 0))
            {
                Position = new Vector2f(pos.X - 10, pos.Y - 40),
                FillColor = Color.Green,
                Scale = scale
            };

            var xTriangle = new Triangle(new Vector2f(0, 0), new Vector2f(0, -20), new Vector2f(20, -10))
            {
                Position = new Vector2f(pos.X + 40, pos.Y + 10),
                FillColor = Color.Red,
                Scale = scale
            };

            var yLine = new Rectangle(5, 60)
            {
                Position = new Vector2f(pos.X, pos.Y - 25),
                FillColor = Color.Green,
                Scale = scale
            };

            var xLine = new Rectangle(60, 5)
            {
                Position = new Vector2f(pos.X + 25, pos.Y),
                FillColor = Color.Red,
                Scale = scale
            };

            EngineService.MainWindow.Draw(yTriangle);
            EngineService.MainWindow.Draw(xTriangle);
            EngineService.MainWindow.Draw(yLine);
            EngineService.MainWindow.Draw(xLine);
        }
    }
}
