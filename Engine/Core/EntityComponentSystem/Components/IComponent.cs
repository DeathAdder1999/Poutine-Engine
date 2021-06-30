using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Engine.Core
{
    /// <summary>
    /// Used to prioritize the rendering pipeline
    /// Physics is the highest priority
    /// </summary>
    public enum ComponentType
    {
        PHYSICS,
        RENDER,
        IGNORE,
        INPUT
    }

    public interface IComponent
    {
        GameObject Owner { get; set; }

        void Update();

        void WriteComponent(XmlWriter writer);
    }
}
