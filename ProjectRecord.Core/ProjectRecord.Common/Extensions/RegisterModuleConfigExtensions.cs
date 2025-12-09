using System.Configuration;
using System.Reflection;
using System.Xml.Serialization;
using Microsoft.Extensions.DependencyInjection;
using ProjectRecord.Common.Module;

namespace ProjectRecord.Common.Extensions;

public static class RegisterModuleConfigExtensions
{
    private static ModulesConfiguration? LoadConfiguration(string configFile)
    {
        var serializer = new XmlSerializer(typeof(ModulesConfiguration));

        using var reader = new StreamReader(configFile);
        if (reader == null)
            throw new FileNotFoundException();
        var result = serializer?.Deserialize(reader) as ModulesConfiguration;

        return result;
    }

    public static IServiceCollection RegisterConfigModule(this IServiceCollection serviceCollection,
        string? moduleFileDir = null)
    {
        var moduleFile = Path.Combine(moduleFileDir ?? AppDomain.CurrentDomain.BaseDirectory,
            "modules.config");

        if (!System.IO.File.Exists(moduleFile))
        {
            throw new FileLoadException(nameof(moduleFileDir));
        }

        var modules = LoadConfiguration(moduleFile);

        if (modules == null)
            throw new FileNotFoundException();

        if (modules.Name != "Modules.Config")
        {
            throw new ConfigurationErrorsException();
        }

        foreach (var itemModule in modules.Modules.Modules)
        {
            var assembly = Assembly.LoadFrom(itemModule.AssemblyFile);
            foreach (var moduleModuleName in itemModule.ModuleNames)
            {
                serviceCollection.RegisterModule(assembly, moduleModuleName);
            }
        }

        return serviceCollection;
    }
}