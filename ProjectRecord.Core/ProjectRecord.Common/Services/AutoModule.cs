using Microsoft.Extensions.DependencyInjection;
using ProjectRecord.Common.Extensions;
using ProjectRecord.Common.Module;

namespace ProjectRecord.Common.Services;

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