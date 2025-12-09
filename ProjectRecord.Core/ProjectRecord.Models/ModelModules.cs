using ProjectRecord.Common.Attribute;
using ProjectRecord.Common.Services;
using ProjectRecord.Models.Mapper;

namespace ProjectRecord.Models;

[Module(nameof(ModelModules))]
public class ModelModules : AutoModule<ModelModules>
{
    public override void OnInitialized(IServiceProvider serviceProvider)
    {
        base.OnInitialized(serviceProvider);

        var db = serviceProvider.GetService(typeof(SysDbContext)) as SysDbContext;
        db?.Database.EnsureCreated();
    }
}