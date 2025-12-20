using WinformCore.Common.Attribute;
using WinformCore.Common.Services;
using WinformCore.Models.Mapper;

namespace WinformCore.Models;

[Module(nameof(ModelModules))]
public class ModelModules : AutoModule<ModelModules>
{
    public override void OnInitialized(IServiceProvider serviceProvider)
    {
        base.OnInitialized(serviceProvider);

        var db = serviceProvider.GetService(typeof(SysDbContext)) as SysDbContext;

        if (db is null)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(SysDbContext));
        }

        db?.Database.EnsureCreated();
    }
}