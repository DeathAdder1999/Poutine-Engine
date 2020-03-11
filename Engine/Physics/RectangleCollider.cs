using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.Render.Shapes;
using SFML.Graphics;

namespace Engine.Physics
{
    public class RectangleCollider : Collider
    {
        private float _width = 1;
        private float _height = 1;
        private float _x = 0;
        private float _y = 0;

        public float Width
        {
            get => _width;
            set
            {
                ((Rectangle) ColliderShape).Width = value;
                _width = value;
            }
        }

        public float Height
        {
            get => _height;
            set
            {
                ((Rectangle) ColliderShape).Height = value;
                _height = value;
            }
        }

        public float X
        {
            get => _x;
            set
            {
                ((Rectangle) ColliderShape).X = value;
                _x = value;
            }
        }

        public float Y
        {
            get => _y;
            set
            {
                ((Rectangle) ColliderShape).Y = value;
                _y = value;
            }
        }

        public RectangleCollider(GameObject owner) : base(owner)
        {
                
        }

        public RectangleCollider(GameObject owner, float x, float y, float width, float height) : base(owner)
        {
            var color = new Color(Color.Green);
            color.A = 100;
            ColliderShape = new Rectangle(x, y, width, height) { FillColor = color};
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
