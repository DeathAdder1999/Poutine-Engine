using Engine.Render.Shapes;
using SFML.Graphics;
using System.Xml;

namespace Engine.Physics
{
    public class RectangleCollider : ColliderComponent
    {
        private float _width = 1;
        private float _height = 1;
        private float _x = 0;
        private float _y = 0;

        [PersistentProperty]
        public float Width
        {
            get => _width;
            set
            {
                ((Rectangle) ColliderShape).Width = value;
                _width = value;
            }
        }

        [PersistentProperty]
        public float Height
        {
            get => _height;
            set
            {
                ((Rectangle) ColliderShape).Height = value;
                _height = value;
            }
        }

        [PersistentProperty]
        public float X
        {
            get => _x;
            set
            {
                ((Rectangle) ColliderShape).X = value;
                _x = value;
            }
        }

        [PersistentProperty]
        public float Y
        {
            get => _y;
            set
            {
                ((Rectangle) ColliderShape).Y = value;
                _y = value;
            }
        }

        public RectangleCollider(float x, float y, float width, float height)
        {
            var color = new Color(Color.Green);
            color.A = 100;
            ColliderShape = new Rectangle(x, y, width, height) { FillColor = color};
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public RectangleCollider() : this(0, 0, 1, 1)
        {

        }
    }
}
