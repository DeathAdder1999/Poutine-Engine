using System;
using MathNet.Numerics.LinearAlgebra;
using SFML.Graphics;
using SFML.System;

namespace Engine.Render.Shapes
{
    public class Triangle : ShapeBase
    {
        /// <summary>
        /// Creates a triangle with specified vertices
        /// </summary>
        public Triangle(Vector2f point1, Vector2f point2, Vector2f point3) : base(3)
        {
            SetPoint(0, point1);
            SetPoint(1, point2);
            SetPoint(2, point3);
        }
    }
}
