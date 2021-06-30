using System.Xml;

namespace Engine.Core
{
    public abstract class ComponentBase : IComponent
    {
        public virtual GameObject Owner { get; set; }

        public bool IsActive { get; set; } = true;

        public ComponentType Type { get; protected set; } = ComponentType.IGNORE;

        public abstract void Update();

        public abstract void WriteComponent(XmlWriter writer);
    }
}
