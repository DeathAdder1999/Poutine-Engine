using System.Xml;
using Engine.Core.SceneManagement;
using Engine.Core;

namespace Engine.IO
{
    public static class SceneWriter
    {
        public static void WriteScene(Scene scene)
        {
            var sts = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };

            using var writer = XmlWriter.Create($"{scene.Name}.poutine", sts);
            writer.WriteStartDocument();
            
            writer.WriteStartElement("Scene");
            writer.WriteAttributeString("name", scene.Name);

            foreach (var sceneChild in scene.Children)
            {
                WriteGameObject(writer, sceneChild);
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        private static void WriteGameObject(XmlWriter writer, GameObject gameObject)
        {
            writer.WriteStartElement("GameObject");
            writer.WriteAttributeString("id", gameObject.Reference.Reference);
            writer.WriteAttributeString("parentId", gameObject.Parent?.Reference.Reference);
            writer.WriteAttributeString("type", gameObject.GetType().ToString());
            writer.WriteAttributeString("name", gameObject.Name);

            writer.WriteStartElement("tag");
            writer.WriteString(gameObject.Tag);
            writer.WriteEndElement();

            writer.WriteStartElement("Transform");

            writer.WriteStartElement("position");
            writer.WriteString(gameObject.Transform.Position.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("rotation");
            writer.WriteString(gameObject.Transform.Rotation.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("scale");
            writer.WriteString(gameObject.Transform.Scale.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.WriteStartElement("isStatic");
            writer.WriteString(gameObject.IsStatic.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("isActive");
            writer.WriteString(gameObject.IsActive.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Components");

            foreach (var component in gameObject.GetComponents<IComponent>())
            {
                WriteComponent(writer, component);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private static void WriteComponent(XmlWriter writer, IComponent component)
        {
            if(component is Physics.PhysicsComponent)
            {
                writer.WriteStartElement("PhysicsComponent");
            }
            else if (component is Render.RenderComponent)
            {
                writer.WriteStartElement("RenderComponent");;
            }
            else if (component is Physics.ColliderComponent)
            {
                writer.WriteStartElement("ColliderComponent");
            }
            else if (component is Core.Input.InputComponent)
            {
                writer.WriteStartElement("InputComponent");
            }

            component.WriteComponent(writer);

            writer.WriteEndElement();
        }
    }
}