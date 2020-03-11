using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using SFML.System;
using MathNet.Numerics;

namespace Engine.Physics
{
    /// <summary>
    /// Essential component of physics based movement
    /// </summary>
    public class PhysicsComponent : ComponentBase
    {
        private Vector2 _velocity;
        private float _angularVelocity;

        public bool UseGravity { get; set; }

        public bool FreezeX { get; set; }

        public bool FreezeY { get; set; }

        public bool FreezeRotation { get; set; }

        public bool DetectCollisions { get; set; }

        public float Mass { get; set; } = 1.0f;

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

        public Vector2 ConstraintsX { get; set; } = new Vector2(float.NegativeInfinity, float.PositiveInfinity);

        public Vector2 ConstraintsY { get; set; } = new Vector2(float.PositiveInfinity, float.NegativeInfinity);

        public Vector2 ConstraintsRotation { get; set; } = new Vector2(float.NegativeInfinity, float.PositiveInfinity);

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

        public PhysicsComponent(GameObject owner) : base(owner)
        {
            Type = ComponentType.PHYSICS;
        }

        public override void Update()
        {
            
        }


    }
}
