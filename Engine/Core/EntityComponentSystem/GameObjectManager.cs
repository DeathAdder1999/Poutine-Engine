using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.ErrorHandler;

namespace Engine.Core.EntityComponentSystem
{
    class GameObjectManager
    {
        public static GameObjectManager Instance = new GameObjectManager();
        private Dictionary<string, GameObject> _gamObjects = new Dictionary<string, GameObject>();

        private GameObjectManager()
        {
        }

        public void Add(GameObject gameObject)
        {
            var objectRef = gameObject.Reference.Reference;

            GameObject g;

            if (_gamObjects.TryGetValue(objectRef, out g))
            {
                throw new DuplicateException("GameObject with given reference already exists!");
            }

            _gamObjects[objectRef] = gameObject;
        }

        public void Remove(string reference)
        {
            if (!_gamObjects.TryGetValue(reference, out var gameObject))
            {
                throw new ElementNotFountException("GameObject with given reference not found!");
            }

            _gamObjects.Remove(reference);
            gameObject.Dispose();
        }

    }
}
