using Microsoft.Extensions.DependencyInjection;

namespace ProjectRecord.Common.Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class AutoFrmViewAttribute : System.Attribute
{
    public AutoFrmViewAttribute(string viewName, Type? dataContext = null,
        ServiceLifetime lifetime = ServiceLifetime.Singleton,
        Type? registerType = null)
    {
        ViewName = viewName;
        DataContext = dataContext;
        Lifetime = lifetime;
        RegisterType = registerType;
    }
    public Type? RegisterType { get; set; }
    public string ViewName { get; set; }

    public Type? DataContext { get; set; }

    public ServiceLifetime Lifetime { get; set; }
}