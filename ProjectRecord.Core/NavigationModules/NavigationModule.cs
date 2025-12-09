using Microsoft.Extensions.DependencyInjection;
using ProjectRecord.Common.Attribute;
using ProjectRecord.Common.Services;

namespace NavigationModules;

[Module(nameof(NavigationModule))]
public class NavigationModule : AutoModule<NavigationModule>
{
    public override void Register(IServiceCollection serviceCollection)
    {
        base.Register(serviceCollection);
    }
}