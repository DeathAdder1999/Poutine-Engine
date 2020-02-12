using System.Collections.Generic;

namespace Engine.Core.SceneManagement
{
    public class SceneManager
    {
        public static SceneManager Instance = new SceneManager();
        private List<Scene> _scenes = new List<Scene>();

        private SceneManager()
        {

        }

        /// <summary>
        /// Loads scene from the name provided. Throws and exception if not found
        /// </summary>
        /// <param name="name"></param>
        public void LoadScene(string name)
        {

        }
        
        public void LoadSceneFromPath(string scenePath)
        {

        }

        /// <summary>
        /// Loads all of the scenes of the current project
        /// </summary>
        public void LoadScenes()
        {

        }
    }
}
