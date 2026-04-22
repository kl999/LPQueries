<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

using System;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

void Main()
    {
        Assembly thisAssembly = typeof(DumpOptions).Assembly;
        foreach (MethodInfo method in GetExtensionMethods(thisAssembly, typeof(object)))
        {
            Console.WriteLine(method);
        }
    }
    static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly, Type extendedType)
    {
        var isGenericTypeDefinition = extendedType.IsGenericType && extendedType.IsTypeDefinition;
        var query = from type in assembly.GetTypes()
            where type.IsSealed && !type.IsGenericType && !type.IsNested
            from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
            where method.IsDefined(typeof(ExtensionAttribute), false)
            where isGenericTypeDefinition
                ? method.GetParameters()[0].ParameterType.IsGenericType && method.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == extendedType
                : method.GetParameters()[0].ParameterType == extendedType
            select method;
        return query;
    }