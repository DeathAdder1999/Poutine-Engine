using System;

namespace Engine
{
    /// <summary>
    /// Attribute for indicating that property is not persistent.
    /// Will be ignored when saving game data.
    /// </summary>
   [AttributeUsage(AttributeTargets.Property)]
   class RuntimeProperty : Attribute
   {
   }
}