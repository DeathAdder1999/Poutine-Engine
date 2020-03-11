using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Engine.Render.Shapes
{
    public class Line : ShapeBase
    {
        public Line(Vector2f vStart, Vector2f vEnd) : base(2)
        {
            SetPoint(0, vStart);
            SetPoint(1, vEnd);
        }

        public Line(float xStart, float xEnd, float yStart, float yEnd) : this(new Vector2f(xStart, xEnd), new Vector2f(xEnd, yEnd))
        {

        }
    }
}
