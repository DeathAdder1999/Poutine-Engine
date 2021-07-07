using System;
using System.Collections.Generic;
using Engine.Core.SceneManagement;
using Engine.Core;
using Engine.Reflection;


namespace Engine.IO
{
    public static class SceneReader
    {
        private static List<Action> _onSceneParsedActions = new List<Action>();

        public static Scene ReadScene(string path)
        {
            using var poutineXmlReader = new PoutineXmlReader(path);
            var element = poutineXmlReader.GetNextXmlElement();

            Scene scene = null;

            while(element != null)
            {
                if(element.Name == "Scene")
                {
                    scene = ParseXmlScene(element);
                }

                element = poutineXmlReader.GetNextXmlElement();
            }

            OnSceneParsed();

            return scene;
        }

        public static Scene ParseXmlScene(PoutineXmlElement element)
        {
            var scene = new Scene(element.Attributes["name"]);

            foreach(var sceneChild in element.Children)
            {
                scene.AddChild(ParseXmlGameObject(sceneChild));
            }

            return scene;
        }

        private static GameObject ParseXmlGameObject(PoutineXmlElement element)
        {
            var type = element.Name;
            var reference = element.Attributes["id"];
            var parentReference = element.Attributes["parentId"];
            var name = element.Attributes["name"];

            var gameObject = PoutineReflection.CreateInstance(type, new GameObjectReference(reference)) as GameObject;
            gameObject.Name = name;
            
            foreach(var child in element.Children)
            {
                if(child.Name == "Transform")
                {
                    gameObject.Transform = ParseXmlTransform(child);
                }
                else if(child.Name == "Components")
                {
                    gameObject.AddComponents(ParseComponents(child).ToArray());
                }
            }

            _onSceneParsedActions.Add(() => {
                if(parentReference.IsNullOrEmpty())
                {
                    return;
                }

                var parent = GameObjectManager.Instance.Get(new GameObjectReference(parentReference));
                gameObject.Parent = parent;
                gameObject.Transform.Parent = parent.Transform;
            });

            return gameObject;
        }

        private static Transform ParseXmlTransform(PoutineXmlElement element)
        {
            return new Transform();
        }

        private static List<IComponent> ParseComponents(PoutineXmlElement element)
        {
            return new List<IComponent>();
        }

        private static void OnSceneParsed()
        {
            foreach (var onSceneParsedAction in _onSceneParsedActions)
            {
                onSceneParsedAction.Invoke();
            }

            _onSceneParsedActions.Clear();
        }
    }
}