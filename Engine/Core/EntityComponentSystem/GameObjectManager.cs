using System;
using System.Collections.Generic;
using Engine.ErrorHandler;

namespace Engine.Core.EntityComponentSystem
{
    class GameObjectManager
    {
        public static GameObjectManager Instance = new GameObjectManager();
        private Dictionary<string, GameObject> _gameObjects = new Dictionary<string, GameObject>();
        public EventHandler<GameObject> GameObjectAdded;

        private GameObjectManager()
        {
        }

        public void Add(GameObject gameObject)
        {
            var objectRef = gameObject.Reference.Reference;

            if (_gameObjects.TryGetValue(objectRef, out var g))
            {
                throw new DuplicateException("GameObject with given reference already exists!");
            }

            _gameObjects[objectRef] = gameObject;
            GameObjectAdded?.Invoke(this, gameObject);
        }

        public void Remove(string reference)
        {
            if (!_gameObjects.TryGetValue(reference, out var gameObject))
            {
                throw new ElementNotFountException("GameObject with given reference not found!");
            }

            _gameObjects.Remove(reference);
            gameObject.Dispose();
        }

    }
}
