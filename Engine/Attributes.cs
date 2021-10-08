using System;

namespace Engine
{
    /// <summary>
    /// Attribute for indicating that property is persistent.
    /// Will saved when saving game data.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    class PersistentProperty : Attribute
    {
    }
}