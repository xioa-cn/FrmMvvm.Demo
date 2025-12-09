using Microsoft.Extensions.DependencyInjection;
using ProjectRecord.Common.Module;

namespace ProjectRecord.Common.Extensions;

public static class UseFrmModuleExtensions
{
    public static IServiceProvider UseFrmModule(this IServiceProvider serviceProvider)
    {
        var modules = serviceProvider.GetServices<IModule>();

        foreach (var module in modules)
        {
            module.OnInitialized(serviceProvider);
        }

        return serviceProvider;
    }
}