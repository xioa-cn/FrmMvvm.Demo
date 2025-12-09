
using Microsoft.Extensions.DependencyInjection;

namespace ProjectRecord.Common.Attribute
{
    [System.AttributeUsage(AttributeTargets.Class)]
    public class AutoFrmVmAttribute : System.Attribute
    {
        public ServiceLifetime Lifetime { get; set; }

        public Type ServiceType { get; set; }

        public AutoFrmVmAttribute(Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            ServiceType = serviceType; Lifetime = lifetime;
        }
    }
}
