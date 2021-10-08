using System;
using System.Linq;
using System.Collections.Generic;
using Engine.ErrorHandler;

namespace Engine.Reflection
{

    public static class PoutineReflection
    {
        private static Dictionary<string, Type> TypeToAssemblyDict { get; } = new Dictionary<string, Type>();

        static PoutineReflection()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var engineAssembly = assemblies.Where(x => x.FullName.Contains("Engine")).First();

            foreach(var typeInfo in engineAssembly.DefinedTypes)
            {
                TypeToAssemblyDict.Add(typeInfo.FullName, typeInfo.AsType());
            }
        }

        public static object CreateInstance(string typeName, params object[] args)
        {
            if(!TypeToAssemblyDict.TryGetValue(typeName, out var type))
            {
                throw new AssemblyNotFoundException($"No assembly containing {typeName} found.");
            }

            return Activator.CreateInstance(type, args);
        }

        public static void SetProperties(object o, Dictionary<string, object> properties)
        {
            var type = o.GetType();
            
            foreach (var property in properties)
            {
                var prop = type.GetProperty(property.Key);
                prop.SetValue(o, property.Value);
            }
        }

        public static void SetProperty(object o, string propertyName, object propertyValue)
        {
            var type = o.GetType();
            var prop = type.GetProperty(propertyName);
            prop.SetValue(o, propertyValue);
        }
    }
}