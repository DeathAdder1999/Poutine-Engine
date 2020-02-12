using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core
{
    public abstract class ComponentBase : IComponent
    {
        public GameObject Owner { get; set; }

        public bool IsActive { get; set; }

        public ComponentType Type { get; protected set; }

        public ComponentBase(GameObject owner)
        {
            Owner = owner;
        }

        public abstract void Update();
    }
}
