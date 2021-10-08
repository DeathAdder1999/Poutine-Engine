using System.IO;
using System.Numerics;
using System.Xml;
using System.Collections.Generic;
using Engine.Core.SceneManagement;
using Engine.Core;
using Engine.Render.Shapes;

namespace Engine.IO
{
    public static class SceneWriter
    {
        static SceneWriter()
        {
            VerifyProjectDirectories();
        }

        public static void WriteScene(Scene scene, string path="")
        {
            var sts = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };

            var fileName = $"{scene.Name}.poutine";

            if(path != string.Empty)
            {
                fileName = Path.Combine(path, fileName);
            }

            using var writer = XmlWriter.Create(fileName, sts);
            writer.WriteStartDocument();
            
            writer.WriteStartElement("Scene");
            writer.WriteAttributeString("name", scene.Name);

            foreach (var sceneChildRef in scene.ChildrenRefs)
            {
                var sceneChild = GameObjectManager.Instance.Get(sceneChildRef);
                WriteGameObject(writer, sceneChild);
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        private static void WriteGameObject(XmlWriter writer, GameObject gameObject)
        {
            writer.WriteStartElement(gameObject.GetType().FullName);
            writer.WriteAttributeString("id", gameObject.Reference.Reference);
            writer.WriteAttributeString("parentId", gameObject.Parent?.Reference.Reference);
            writer.WriteAttributeString("name", gameObject.Name);

            WriteObject(writer, gameObject);

            writer.WriteStartElement("Components");

            foreach (var component in gameObject.GetComponents<IComponent>())
            {
                writer.WriteStartElement(component.GetType().Name);
                WriteObject(writer, component);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private static void WriteObject(XmlWriter writer, object o, List<string> propertiesToIgnore=null)
        {
            var propertiesDict = o.GetPersistentProperties();

            foreach(var kvp in propertiesDict)
            {
                if (propertiesToIgnore?.Contains(kvp.Key) ?? false)
                {
                    continue;
                }

                if (kvp.Value != null)
                {
                    WriteProperty(writer, kvp.Key, kvp.Value);
                }
            }
        }

        private static void WriteProperty(XmlWriter writer, string property, object value)
        {
            writer.WriteStartElement(property);

            if (value is Vector2 v)
            {
                writer.WriteString($"{v.X}, {v.Y}");
            }
            else if (value is SFML.Graphics.Color c)
            {
                writer.WriteString($"{c.R}, {c.G}, {c.B}, {c.A}");
            }
            else if (value is Transform t)
            {
                WriteElement(writer, "Position", $"{t.Position.X}, {t.Position.Y}");
                WriteElement(writer, "Rotation", t.Rotation.ToString());
                WriteElement(writer, "Scale", $"{t.Scale.X}, {t.Scale.Y}");
            }
            else if (value is ShapeBase)
            {
                WriteObject(writer, value);
            }
            else
            {
                writer.WriteString(value.ToString());
            }
            
            writer.WriteEndElement();
        }

        private static void WriteElement(XmlWriter writer, string property, string value)
        {
            writer.WriteStartElement(property);
            writer.WriteString(value);
            writer.WriteEndElement();
        }


        private static void VerifyProjectDirectories()
        {

        }
    }
}