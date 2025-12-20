
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WinformCore.Common.Extensions
{
    public static class RegisterFrmVmExtensions
    {
        public static IServiceCollection RegisterAutoFrmVmServices(this IServiceCollection serviceCollection,
           Assembly assembly)
        {
            var types = assembly.GetTypes().Where(item =>
                item is { IsAbstract: false, IsInterface: false } && !item.IsValueType &&
                item.GetCustomAttribute<Attribute.AutoFrmVmAttribute>() != null);

            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<Attribute.AutoFrmVmAttribute>();

                if (attr is null)
                {
                    continue;
                }

                if (attr.Lifetime == ServiceLifetime.Singleton)
                {
                    serviceCollection.AddSingleton(attr.ServiceType ?? type, type);
                }
                else if (attr.Lifetime == ServiceLifetime.Scoped)
                {
                    serviceCollection.AddScoped(attr.ServiceType ?? type, type);
                }
                else if (attr.Lifetime == ServiceLifetime.Transient)
                {
                    serviceCollection.AddTransient(attr.ServiceType ?? type, type);
                }
            }

            return serviceCollection;
        }

        public static IServiceCollection RegisterAutoFrmVmServices<T>(this IServiceCollection serviceCollection)
        {
            return serviceCollection.RegisterAutoFrmVmServices(typeof(T).Assembly);
        }

    }
}
