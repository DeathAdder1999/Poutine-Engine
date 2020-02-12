using System.Collections.Generic;

namespace Engine.Core
{
    public class Scene
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public List<GameObject> Children { get; }

        public bool IsLoaded { get; private set; } = false;

        public Scene(string name)
        {
            Name = name;
            Children = new List<GameObject>();
        }

        /// <summary>
        /// Loads all of the contents into the scene
        /// </summary>
        public void Load()
        {

        }

    }
}
