using System;
using System.Collections.Generic;
using System.Numerics;
using Engine.ErrorHandler;

namespace Engine.Core
{
    /// <summary>
    /// The base class for all of the GameObjects.
    /// </summary>

    public abstract class GameObject : IDisposable
    {
        public GameObjectReference Reference { get; }

        public bool Disposed { get; private set; }

        public GameObject Parent { get; set; }

        public bool IsDirty { get; set; }

        public bool IsStatic { get; set; }

        public string Tag { get; set; }

        #region Game Specific Properties

        private List<IComponent> _components = new List<IComponent>();

        public Transform Transform { get; set; }

        #endregion

        protected GameObject()
        {
            Reference = new GameObjectReference(Utils.GetUniqueReference());
            Transform = new Transform() {Position = new Vector2(0, 0)};
        }

        protected GameObject(GameObjectReference reference)
        {
            Reference = reference;
            Transform = new Transform() { Position = new Vector2(0, 0) };
        }

        protected GameObject(GameObjectReference reference, GameObject parent) : this(reference)
        {
            Parent = parent;
            Transform.Parent = parent.Transform.Parent;
        }

        protected GameObject(GameObject parent) : this()
        {
            Parent = parent;
            Transform.Parent = parent.Transform.Parent;
        }

        public void AddComponent(IComponent component)
        {
            if (_components.Contains(component))
            {
                throw new DuplicateException("GameObject cannot have the same component twice");
            }

            _components.Add(component);
        }

        public void AddComponents(params IComponent[] components)
        {
            foreach (var c in components)
            {
                AddComponent(c);
            }
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        /// <summary>
        /// Uses GetComponent<T>() underneath, not optimal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>true if GameObject has the component specified</returns>
        public bool HasComponent<T>() where T : IComponent
        {
            return GetComponent<T>() != null;
        }

        public T GetComponent<T>() where T : IComponent
        {
            foreach (var component in _components)
            {
                if (component is T)
                {
                    return (T) component;
                }
            }

            return default(T);
        }

        public bool TryGetComponent<T>(out T component) where T : IComponent
        {
            component = GetComponent<T>();

            return !component.Equals(default);
        }

        public void UpdateComponent<T>() where T : IComponent
        {
            GetComponent<T>()?.Update();
        }

        /// <summary>
        /// Returns list of components of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetComponents<T>() where T : IComponent
        {
            var list = new List<T>();

            foreach (var component in _components)
            {
                if (component is T c)
                {
                    list.Add(c);
                }
            }

            return list;
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

            //TODO implement
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
