using Microsoft.Extensions.DependencyInjection;

namespace WinformCore.Common.Module;

public interface IModule
{
    void Register(IServiceCollection serviceCollection);


    void OnInitialized(IServiceProvider serviceProvider);
}