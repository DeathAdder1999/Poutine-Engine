using System.Numerics;
using Engine.Core;
using Engine.Render;
using Engine.Render.Shapes;

namespace Engine.Prebuilt
{
    public class Rectangle : GameObject
    {
        public float Width => Shape.GetLocalBounds().Width;

        public float Height => Shape.GetLocalBounds().Height;

        public float X { get; set; }

        public float Y { get; set; }

        private ShapeBase Shape { get; set; }

        public Rectangle(GameObjectReference reference) : base(reference)
        {
            X = 0;
            Y = 0;

            AddRectangleComponent(1, 1);
        }

        public Rectangle() : this(0f, 0f, 1f, 1f)
        {
        }

        public Rectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;

            Transform.Position = new Vector2(X, Y);
            AddRectangleComponent(width, height);
        }

        public Rectangle(float width, float height) : this(0, 0, width, height)
        {

        }

        private void AddRectangleComponent(float width, float height)
        {
            var r = new RenderComponent() { Shape = new Render.Shapes.Rectangle(width, height) };
            Shape = r.Shape;
            AddComponent(r);
        }
    }
}
