using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using SFML.System;

namespace Engine.Render.Shapes
{
    public class Rectangle : ShapeBase
    {
        private float _width;
        private float _height;
        private float _x;
        private float _y;

        public float Width
        {
            get => _width;
            set
            {
                var scaleX = value / _width;
                _width = value;
                Scale = new Vector2f(scaleX, Scale.Y);
            }
        }

        public float Height
        {
            get => _height;
            set
            {
                var scaleY = value / _height;
                _height = value;
                Scale = new Vector2f(Scale.X, scaleY);
            }
        }

        public float X
        {
            get => _x;
            set
            {
                var deltaX = value - _x;
                _x = value;
                Translate(deltaX, 0);
            }
        }

        public float Y
        {
            get => _y;
            set
            {
                var deltaY = value - _y;
                _y = value;
                Translate(0, -deltaY);
            }
        }

        public Rectangle(float x, float y, float width, float height) : base(4)
        {
            _width = width;
            _height = height;
            _x = x;
            _y = y;

            var p1 = new Vector2f(x - width / 2, y + height / 2);
            var p2 = new Vector2f(x + width / 2, y + height / 2);
            var p3 = new Vector2f(x + width / 2, y - height / 2);
            var p4 = new Vector2f(x - width / 2, y - height / 2);

            SetPoint(0, p1);
            SetPoint(1, p2);
            SetPoint(2, p3);
            SetPoint(3, p4);
        }

        public Rectangle(Vector2f center, float width, float height) : this(center.X, center.Y, width, height)
        {

        }

        public Rectangle(float width, float height) : this(0 , 0, width, height)
        {

        }

        public Rectangle(Vector2f size) : this(size.X, size.Y)
        {

        }
    }
}
