using System.Collections.Generic;
using Engine.ErrorHandler;

namespace Engine.Core.SceneManagement
{
    public class Scene
    {
        private List<GameObjectReference> _childrenRefs;

        private bool _isActive;


        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsLoaded { get; private set; } = false;
        public bool IsDirty { get; set; } = false;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if(_isActive == value)
                {
                    return;
                }

                foreach(var childRef in _childrenRefs)
                {
                    var gameObject = GameObjectManager.Instance.Get(childRef);
                    gameObject.IsActive = value;
                }
            }
        }

        //TODO dict???
        public List<GameObjectReference> ChildrenRefs => _childrenRefs.Copy();

        public Scene(string name)
        {
            Name = name;
            _childrenRefs = new List<GameObjectReference>();
        }

        public void AddChild(GameObject child)
        {
            if (_childrenRefs.Contains(child.Reference))
            {
                throw new DuplicateException("GameObject is already in Scene hierarchy.");
            }

            _childrenRefs.Add(child.Reference);
        }

        public void AddChildren(IEnumerable<GameObject> children)
        {
            foreach(var child in children)
            {
                AddChild(child);
            }
        }
    }
}
