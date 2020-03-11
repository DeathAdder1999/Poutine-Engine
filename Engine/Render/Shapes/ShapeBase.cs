using System;
using System.Drawing;
using SFML.Graphics;
using SFML.System;

namespace Engine.Render.Shapes
{
    public class ShapeBase : ConvexShape
    {

        protected ShapeBase(uint pointCount) : base(pointCount)
        {

        }

        public void SetPosition(Vector2f pos)
        {
            Transform.TransformPoint(pos);
        }

        public void SetPosition(float x, float y)
        {
            Transform.TransformPoint(x, y);
        }

        public void Translate(Vector2f delta)
        {
            Transform.Translate(delta);
        }

        public void Translate(float x, float y)
        {
            Transform.Translate(x, y);
        }

        public void Rotate(float angle)
        {
            Transform.Rotate(angle);
        }

        public void Rotate(float angle, Vector2f center)
        {
            Transform.Rotate(angle, center);
        }

        public void Rotate(float angle, float x, float y)
        {
            Transform.Rotate(angle, x, y);
        }

        public bool Intersects(Shape other)
        {
            var otherBounds = other.GetGlobalBounds();
            var p1 = new PointF(otherBounds.Left, otherBounds.Top);
            var p2 = new PointF(otherBounds.Left + otherBounds.Width, otherBounds.Top);
            var p3 = new PointF(otherBounds.Left, otherBounds.Top + otherBounds.Height);
            var p4 = new PointF(otherBounds.Left + otherBounds.Width, otherBounds.Top + otherBounds.Height);


            return this.Contains(p1) || this.Contains(p2) || this.Contains(p3) || this.Contains(p4);
            //return GetLocalBounds().Intersects(other.GetLocalBounds());
        }

    }
}
