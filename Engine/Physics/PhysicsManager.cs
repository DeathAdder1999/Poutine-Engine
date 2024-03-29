﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;

namespace Engine.Physics
{
    public class PhysicsManager
    {
        private static PhysicsManager _instance;
        private List<ColliderComponent> _colliders = new List<ColliderComponent>();
        private List<PhysicsComponent> _components = new List<PhysicsComponent>();

        public static PhysicsManager Instance => _instance ?? (_instance = new PhysicsManager());

        private PhysicsManager()
        {
            GameObjectManager.Instance.GameObjectAdded += OnGameObjectAdded;
        }

        private void OnGameObjectAdded(object sender, GameObject e)
        {
            if (e.TryGetComponent<ColliderComponent>(out var collider))
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
                if (component.IsActive)
                {
                    component.Update();
                }
            }

            //TODO optimize
            for (var i = 0; i < _colliders.Count; i++)
            {
                if(!_colliders[i].IsActive)
                {
                    continue;
                }

                for (var j = i; j < _colliders.Count; j++)
                {
                    _colliders[i].Update();
                    _colliders[i].CheckCollision(_colliders[j]);
                }
            }
        }
    }
}
