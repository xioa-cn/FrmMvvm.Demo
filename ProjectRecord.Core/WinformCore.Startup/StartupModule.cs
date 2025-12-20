using Microsoft.Extensions.DependencyInjection;
using WinformCore.Common.Attribute;
using WinformCore.Common.Services;

namespace WinformCore.Startup;

[Module(nameof(WinformCore))]
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