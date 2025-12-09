using Microsoft.Extensions.DependencyInjection;

namespace ProjectRecord.Common.Module;

public interface IModule
{
    void Register(IServiceCollection serviceCollection);


    void OnInitialized(IServiceProvider serviceProvider);
}