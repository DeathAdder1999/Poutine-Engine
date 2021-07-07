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
    }
}