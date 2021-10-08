using System.Numerics;
using Engine.Core;
using System.Xml;

namespace Engine.Physics
{
    /// <summary>
    /// Essential component of physics based movement
    /// </summary>
    public class PhysicsComponent : ComponentBase
    {
        private Vector2 _velocity;
        private float _angularVelocity;

        [PersistentProperty]
        public bool UseGravity { get; set; }

        [PersistentProperty]
        public bool FreezeX { get; set; }

        [PersistentProperty]
        public bool FreezeY { get; set; }

        [PersistentProperty]
        public bool FreezeRotation { get; set; }

        [PersistentProperty]
        public bool DetectCollisions { get; set; }

        [PersistentProperty]
        public float Mass { get; set; } = 1.0f;

        [PersistentProperty]
        public Vector2 Velocity
        {
            get => _velocity;
            set
            {
                _velocity.X = value.X;
                _velocity.Y = value.Y;

                if (_velocity.X < ConstraintsX.X)
                {
                    _velocity.X = ConstraintsX.X;
                }

                if (_velocity.X > ConstraintsX.X)
                {
                    _velocity.X = ConstraintsX.X;
                }

                if (_velocity.Y < ConstraintsY.Y)
                {
                    _velocity.Y = ConstraintsY.Y;
                }

                if (_velocity.Y < ConstraintsY.Y)
                {
                    _velocity.Y = ConstraintsX.Y;
                }
            }
        }

        [PersistentProperty]
        public Vector2 ConstraintsX { get; set; } = new Vector2(float.NegativeInfinity, float.PositiveInfinity);

        [PersistentProperty]
        public Vector2 ConstraintsY { get; set; } = new Vector2(float.PositiveInfinity, float.NegativeInfinity);

        [PersistentProperty]
        public Vector2 ConstraintsRotation { get; set; } = new Vector2(float.NegativeInfinity, float.PositiveInfinity);

        [PersistentProperty]
        public float AngularVelocity
        {
            get => _angularVelocity;
            set
            {
                _angularVelocity = value;

                if (ConstraintsRotation.X > AngularVelocity)
                {
                    _angularVelocity = ConstraintsRotation.X;
                }

                if (ConstraintsRotation.Y > AngularVelocity)
                {
                    _angularVelocity = ConstraintsRotation.X;
                }
            }
        }

        public PhysicsComponent()
        {
            Type = ComponentType.PHYSICS;
        }

        public override void Update()
        {
            
        }
    }
}
