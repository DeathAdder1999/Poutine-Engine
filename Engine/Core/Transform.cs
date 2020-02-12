using System.Numerics;

namespace Engine.Core
{
    public class Transform
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Transform Parent { get; set; }
    }
}
