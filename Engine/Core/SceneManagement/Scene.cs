using System.Collections.Generic;
using Engine.ErrorHandler;

namespace Engine.Core.SceneManagement
{
    public class Scene
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsLoaded { get; private set; } = false;
        public bool IsDirty { get; set; } = false;

        //TODO dict???
        public List<GameObject> Children => _children.Copy();

        private List<GameObject> _children;

        public Scene(string name)
        {
            Name = name;
            _children = new List<GameObject>();
        }

        public void AddChild(GameObject child)
        {
            if (_children.Contains(child))
            {
                throw new DuplicateException("GameObject is already in Scene hierarchy.");
            }

            _children.Add(child);
        }

        public void AddChildren(IEnumerable<GameObject> children)
        {
            foreach(var child in children)
            {
                AddChild(child);
            }
        }

        /// <summary>
        /// Loads all of the contents into the scene
        /// </summary>
        public void Load()
        {
            
        }
    }
}
