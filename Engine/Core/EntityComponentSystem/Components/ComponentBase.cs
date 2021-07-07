using System.Xml;

namespace Engine.Core
{
    public abstract class ComponentBase : IComponent
    {
        [RuntimeProperty]
        public virtual GameObject Owner { get; set; }

        public bool IsActive { get; set; } = true;

        [RuntimeProperty]
        public ComponentType Type { get; protected set; } = ComponentType.IGNORE;

        public abstract void Update();
    }
}
