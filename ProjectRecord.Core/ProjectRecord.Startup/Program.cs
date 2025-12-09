using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRecord.Common.Extensions;
using ProjectRecord.Common.Utils;
using ProjectRecord.Models.Configs;
using ProjectRecord.Models.Mapper;

namespace ProjectRecord.Startup;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) => Run(args);
    
    
    public static void Run(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var configuration = builder.Build();
        var appSettings = configuration.Get<AppSettings>();
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton(appSettings!);
        serviceCollection.AddSingleton<SysDbContext>();
        // 手动注入模块
        serviceCollection.RegisterModule<StartupModule>();
        
        // 自动加载 modules.Config 中的模块
        serviceCollection.RegisterConfigModule();

        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        // 启用模块化
        serviceProvider.UseFrmModule();
        
        DispatcherHelper.Initialize();
        ApplicationConfiguration.Initialize();

        var indexFrm = serviceProvider.GetKeyedService<Form>("LoginFrm") ?? throw new ArgumentException();
        Application.Run(indexFrm);
    }
}