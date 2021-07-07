using System.Collections.Generic;
using Engine.ErrorHandler;
using Engine.IO;

namespace Engine.Core.SceneManagement
{
    public class SceneManager
    {
        public static SceneManager Instance = new SceneManager();
        private Dictionary<string, PoutineXmlElement> _scenes = new Dictionary<string, PoutineXmlElement>();
        private Scene _activeScene;

        public Scene ActiveScene
        {
            get => _activeScene;
            set
            {
                if(value != _activeScene)
                {
                    if (_activeScene != null)
                    {
                        _activeScene.IsActive = false;
                    }

                    _activeScene = value;
                    _activeScene.IsActive = true;
                }
            }
        }

        private SceneManager()
        {

        }

        /// <summary>
        /// Loads scene from the name provided. Throws and exception if not found
        /// </summary>
        /// <param name="name"></param>
        public void LoadScene(string name)
        {
            if(!_scenes.TryGetValue(name, out var xmlScene))
            {
                throw new ElementNotFountException($"Scene {name} not found!");
            }

            var scene = SceneReader.ParseXmlScene(xmlScene);
            ActiveScene = scene;
        }
        
        public void LoadSceneFromPath(string scenePath)
        {
            Scene scene = null;

            try
            {
                scene = SceneReader.ReadScene(scenePath);
            }
            catch(System.Exception e)
            {

            }
            
            if(scene == null)
            {
                throw new CorruptedFileException($"Scene file is corrupted {scenePath}");
            }

            ActiveScene = scene;
        }

        /// <summary>
        /// Loads all of the scenes of the current project
        /// </summary>
        public void LoadScenes()
        {
           
        }

        // TODO delete
        public void AddScene(PoutineXmlElement scene)
        {
            _scenes.Add(scene.Name, scene);
        }
    }
}
