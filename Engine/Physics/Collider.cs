using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.ErrorHandler;

namespace Engine.Physics
{
    /// <summary>
    /// Base class for Physics Colliders
    /// </summary>
    public abstract class Collider : ComponentBase
    {
        private PhysicsComponent _physics;

        public EventHandler<CollisionInfo> CollisionEnter;
        public EventHandler<CollisionInfo> CollisionExit;
        public EventHandler<CollisionInfo> CollisionStay;
        public EventHandler<CollisionInfo> TriggerEnter;
        public EventHandler<CollisionInfo> TriggerExit;
        public EventHandler<CollisionInfo> TriggerStay;

        public Vector2 DetectionOffset { get; set; }

        public bool IsTrigger { get; set; }

        public bool IsActive { get; set; }

        protected Collider(GameObject owner) : base(owner)
        {
            _physics = Owner.GetComponent<PhysicsComponent>();

            if (_physics == null)
            {
                throw new MissingComponentException("Collider Component requires Physics Component to be attached");
            }

        }

        public abstract void CheckCollision();
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
