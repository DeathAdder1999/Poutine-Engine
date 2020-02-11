using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.EntityComponentSystem.Components
{
    /// <summary>
    /// Used to prioritize the rendering pipeline
    /// Physics is the highest priority
    /// </summary>
    enum ComponentType
    {
        PHYSICS,
        RENDER
    }

    public interface IComponent
    {
        GameObject Owner { get; set; }

        void Update();
    }
}
