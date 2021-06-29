using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.ErrorHandler;
using Engine.Render.Shapes;
using SFML.Graphics;
using SFML.System;

namespace Engine.Physics
{
    /// <summary>
    /// Base class for Physics Colliders
    /// </summary>
    public abstract class Collider : ComponentBase
    {
        private PhysicsComponent _physics;

        public ShapeBase ColliderShape { get; protected set; }

        public EventHandler<CollisionInfo> CollisionEnter;
        public EventHandler<CollisionInfo> CollisionExit;
        public EventHandler<CollisionInfo> CollisionStay;
        public EventHandler<CollisionInfo> TriggerEnter;
        public EventHandler<CollisionInfo> TriggerExit;
        public EventHandler<CollisionInfo> TriggerStay;

        public override GameObject Owner 
        { 
            get => base.Owner; 
            set 
            {
                base.Owner = value;
                _physics = base.Owner.GetComponent<PhysicsComponent>();
            }
        }

        public Vector2 DetectionOffset { get; set; }

        public bool IsTrigger { get; set; }
        public bool DetectSelfCollision { get; set; }

        protected Collider()
        {
        }

        public override void Update()
        {
            var pos = Owner.Transform.Position;
            ColliderShape.Position = new Vector2f(pos.X, pos.Y);
        }

        public void CheckCollision(Collider other)
        {
            if (!DetectSelfCollision && other.Owner == Owner)
            {
                return;               
            }

            //TODO make sure the proper triggered
            if (ColliderShape.Intersects(other.ColliderShape))
            {
                CollisionEnter?.Invoke(this, new CollisionInfo() {c1 = this, c2 = other});
            }
        }
    }

    /// <summary>
    /// Contains information about the collison
    /// </summary>
    public struct CollisionInfo
    {
        public Collider c1;
        public Collider c2;
        //TODO add time 
    }
}
