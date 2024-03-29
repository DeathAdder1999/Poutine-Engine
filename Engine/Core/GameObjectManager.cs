﻿using System;
using System.Collections.Generic;
using Engine.Core.Input;
using Engine.ErrorHandler;

namespace Engine.Core
{
    class GameObjectManager
    {
        private static GameObjectManager _instance;
        public static GameObjectManager Instance => _instance ?? (_instance = new GameObjectManager());
        private Dictionary<GameObjectReference, GameObject> _gameObjects = new Dictionary<GameObjectReference, GameObject>();
        public EventHandler<GameObject> GameObjectAdded;

        private GameObjectManager()
        {
        }

        public void Add(GameObject gameObject)
        {
            var objectRef = gameObject.Reference;

            if (_gameObjects.TryGetValue(objectRef, out var g))
            {
                throw new DuplicateException("GameObject with given reference already exists!");
            }

            _gameObjects[objectRef] = gameObject;
            GameObjectAdded?.Invoke(this, gameObject);
        }

        
        public void Add(params GameObject[] gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                Add(gameObject);
            }
        }

        public void Remove(GameObjectReference reference)
        {
            if (!_gameObjects.TryGetValue(reference, out var gameObject))
            {
                throw new ElementNotFountException("GameObject with given reference not found!");
            }

            _gameObjects.Remove(reference);
            gameObject.Dispose();
        }

        public GameObject Get(GameObjectReference reference)
        {
            _gameObjects.TryGetValue(reference, out var gameObject);
            return gameObject;
        }

        public GameObject GetSelectionFromMouse(MousePosition pos)
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject.Value.IsUnderMouse(pos))
                {
                    return gameObject.Value;
                }
            }

            return null;
        }
    }
}
