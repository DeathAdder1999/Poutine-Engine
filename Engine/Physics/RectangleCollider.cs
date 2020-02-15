using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;

namespace Engine.Physics
{
    public class RectangleCollider : Collider
    {
        public float Width { get; set; } = 1;

        public float Height { get; set; } = 1;

        public float X { get; set; } = 0;

        public float Y { get; set; } = 0;

        public RectangleCollider(GameObject owner) : base(owner)
        {
        }

        public RectangleCollider(GameObject owner, float x, float y, float width, float height) : base(owner)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public override void CheckCollision(Collider other)
        {
            
        }
    }
}
