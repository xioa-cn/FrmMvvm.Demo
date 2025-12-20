using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WinformCore.Common.Extensions
{
    public static class RegisterFrmExtensions
    {
        extension(IServiceCollection serviceCollection)
        {
            public IServiceCollection RegisterAutoFrmServices(Assembly assembly)
            {
                var types = assembly.GetTypes().Where(item =>
                    item is { IsAbstract: false, IsInterface: false } && !item.IsValueType &&
                    item.GetCustomAttribute<Attribute.AutoFrmViewAttribute>() != null);

                foreach (var type in types)
                {
                    var attr = type.GetCustomAttribute<Attribute.AutoFrmViewAttribute>();

                    if (attr is null)
                    {
                        continue;
                    }

                    if (attr.Lifetime == ServiceLifetime.Singleton)
                    {
                        serviceCollection.AddKeyedSingleton(attr.RegisterType ?? type, attr.ViewName ?? nameof(type), type);
                    }
                    else if (attr.Lifetime == ServiceLifetime.Scoped)
                    {
                        serviceCollection.AddKeyedScoped(attr.RegisterType ?? type, attr.ViewName ?? nameof(type), type);
                    }
                    else if (attr.Lifetime == ServiceLifetime.Transient)
                    {
                        serviceCollection.AddKeyedTransient(attr.RegisterType ?? type, attr.ViewName ?? nameof(type), type);
                    }
                }

                return serviceCollection;
            }

            public IServiceCollection RegisterAutoFrmServices<T>()
            {
                return serviceCollection.RegisterAutoFrmServices(typeof(T).Assembly);
            }
        }
    }
}
