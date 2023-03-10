using System.Reflection;
using AutoMapper;

namespace TestTask.Application.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly)
    {
        ApplyMappingFromAssembly(assembly);
    }

    private void ApplyMappingFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(i => i.GetInterfaces().Any(j => j.IsGenericType && j.GetGenericTypeDefinition() == typeof(IMapWith<>))).ToList();
        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] {this});
        }
    }
}