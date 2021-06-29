using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core
{
    public abstract class ComponentBase : IComponent
    {
        public virtual GameObject Owner { get; set; }

        public bool IsActive { get; set; } = true;

        public ComponentType Type { get; protected set; } = ComponentType.IGNORE;

        public abstract void Update();
    }
}
