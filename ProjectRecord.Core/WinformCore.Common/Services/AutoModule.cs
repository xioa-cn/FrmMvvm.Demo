using Microsoft.Extensions.DependencyInjection;
using WinformCore.Common.Extensions;
using WinformCore.Common.Module;

namespace WinformCore.Common.Services;

public abstract class AutoModule<T> : IModule
{
    protected AutoModule()
    {
    }

    public virtual void Register(IServiceCollection serviceCollection)
    {
        serviceCollection.RegisterAutoFrmServices<T>();
        serviceCollection.RegisterAutoFrmVmServices<T>();
    }

    public virtual void OnInitialized(IServiceProvider serviceProvider)
    {
    }
}