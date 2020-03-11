using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.Core.EntityComponentSystem;

namespace Engine.Physics
{
    public class PhysicsManager
    {
        private static PhysicsManager _instance;
        private List<Collider> _colliders = new List<Collider>();
        private List<PhysicsComponent> _components = new List<PhysicsComponent>();

        public static PhysicsManager Instance => _instance ?? (_instance = new PhysicsManager());

        private PhysicsManager()
        {
            GameObjectManager.Instance.GameObjectAdded += OnGameObjectAdded;
        }

        private void OnGameObjectAdded(object sender, GameObject e)
        {
            if (e.TryGetComponent<Collider>(out var collider))
            {
                _colliders.Add(collider);
            }

            if (e.TryGetComponent<PhysicsComponent>(out var component))
            {
                _components.Add(component);
            }
        }

        /// <summary>
        /// Physics update
        /// Collision Detection
        /// </summary>
        public void Update()
        {
            foreach (var component in _components)
            {
                component.Update();
            }

            for (var i = 0; i < _colliders.Count; i++)
            {
                for (var j = i; j < _colliders.Count; j++)
                {
                    _colliders[i].Update();
                    _colliders[i].CheckCollision(_colliders[j]);
                }
            }
        }
    }
}
