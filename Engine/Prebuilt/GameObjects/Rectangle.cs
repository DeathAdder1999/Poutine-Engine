using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;

namespace Engine.Prebuilt
{
    public class Rectangle : GameObject
    {
        public float Width { get; set; }

        public float Height { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public Rectangle(GameObjectReference reference) : base(reference)
        {
            X = 0;
            Y = 0;
            Width = 1;
            Height = 1;
        }

        public Rectangle()
        {
            X = 0;
            Y = 0;
            Width = 1;
            Height = 1;
        }

        public Rectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            Transform.Position = new Vector2(X, Y);
        }

        public Rectangle(float width, float height) : this(0, 0, width, height)
        {
        }
    }
}
