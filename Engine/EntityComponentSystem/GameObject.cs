using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.EntityComponentSystem.Components;

namespace Engine.EntityComponentSystem
{
    /// <summary>
    /// The base class for all of the GameObjects.
    /// </summary>

    public abstract class GameObject : IDisposable
    {
        public GameObjectReference Reference { get; }

        public bool Disposed { get; private set; }

        public GameObject Parent { get; set; }

        #region Game Specific Properties

        private List<IComponent> _components = new List<IComponent>();

        public Transform Transform { get; set; }

        #endregion

        protected GameObject()
        {
            Reference = new GameObjectReference(Utils.GetUniqueReference());
        }

        protected GameObject(GameObjectReference reference)
        {
            Reference = reference;
        }

        protected GameObject(GameObjectReference reference, GameObject parent) : this(reference)
        {
            Parent = parent;
        }

        private GameObject(GameObject parent)
        {
            Parent = parent;
        }

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        /// <summary>
        /// Called once per frame, updates the game logic for the game object
        /// </summary>
        public virtual void Update()
        {
            //TODO implement
        }

        public virtual void Dispose()
        {
            Disposed = true;
        }

        public static bool operator ==(GameObject o1, GameObject o2)
        {
            return o1.Reference == o2.Reference;
        }

        public static bool operator !=(GameObject o1, GameObject o2)
        {
            return !(o1 == o2);
        }

        protected bool Equals(GameObject other)
        {
            return Equals(Reference, other.Reference) && Disposed == other.Disposed && Equals(Parent, other.Parent);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((GameObject)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Reference != null ? Reference.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Disposed.GetHashCode();
                hashCode = (hashCode * 397) ^ (Parent != null ? Parent.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
