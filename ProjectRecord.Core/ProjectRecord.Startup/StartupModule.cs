using Microsoft.Extensions.DependencyInjection;
using ProjectRecord.Common.Attribute;
using ProjectRecord.Common.Services;

namespace ProjectRecord.Startup;

[Module(nameof(ProjectRecord))]
public class StartupModule : AutoModule<StartupModule>
{
    public override void Register(IServiceCollection serviceCollection)
    {
        base.Register(serviceCollection);
    }

    public override void OnInitialized(IServiceProvider serviceProvider)
    {
        base.OnInitialized(serviceProvider);
    }
}