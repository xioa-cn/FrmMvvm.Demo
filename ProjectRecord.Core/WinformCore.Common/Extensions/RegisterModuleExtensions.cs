using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WinformCore.Common.Attribute;
using WinformCore.Common.Module;

namespace WinformCore.Common.Extensions;

public static class RegisterModuleExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection RegisterModule(Assembly assembly, string? moduleName = null)
        {
            var modules = assembly.GetTypes().Where(item =>
                item is { IsAbstract: false, IsInterface: false } && !item.IsValueType &&
                item.GetCustomAttribute<ModuleAttribute>() != null && typeof(IModule).IsAssignableFrom(item));

            if (!string.IsNullOrEmpty(moduleName))
            {
                modules = modules.Where(item =>
                    item.GetCustomAttribute<ModuleAttribute>()!.ModuleName == moduleName);
            }

            foreach (var module in modules)
            {
                var instance = Activator.CreateInstance(module) as IModule;
                instance?.Register(serviceCollection);
                serviceCollection.AddSingleton<IModule>(instance!);
            }

            return serviceCollection;
        }

        public IServiceCollection RegisterModule<T>(string? moduleName = null)
        {
            return serviceCollection.RegisterModule(typeof(T).Assembly, moduleName);
        }
    }
}