using System.Reflection;
using System.Runtime.Loader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using WinformCore.Common.Extensions;
using WinformCore.Common.Utils;
using WinformCore.Models.Configs;
using WinformCore.Models.Db;

namespace WinformCore.Models.Db;

public abstract class EfDataContext : DbContext
{
    /// <summary>
    /// 数据库连接字符串，子类必须实现此属性
    /// </summary>
    protected abstract string ConnectionString { get; }

    protected abstract AppSettings AppSettings { get; }

    /// <summary>
    /// 实体跟踪设置
    /// 设置为true时跟踪实体变化，false时不跟踪  启用跟踪（适用于需要更新的场景）禁用跟踪（适用于只读查询场景）
    /// </summary>
    public bool QueryTracking
    {
        set
        {
            this.ChangeTracker.QueryTrackingBehavior = value
                ? QueryTrackingBehavior.TrackAll
                : QueryTrackingBehavior.NoTracking;
        }
    }

    /// <summary>
    /// 默认构造函数
    /// </summary>
    public EfDataContext() : base()
    {
    }


    /// <summary>
    /// 带配置的构造函数
    /// </summary>
    /// <param name="options">数据库上下文配置选项</param>
    public EfDataContext(DbContextOptions<EfDataContext> options) : base(options)
    {
    }


    protected void UseDbType(DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        if (AppSettings.DbSetting.DbType == DbType.MySql)
        {
            // 指定 MySQL 版本
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion, options =>
            {
                // 配置MySQL重试策略
                options.EnableRetryOnFailure(
                    maxRetryCount: 3, // 最多重试3次
                    maxRetryDelay: TimeSpan.FromSeconds(10), // 重试延迟10秒
                    errorNumbersToAdd: null); // 需要重试的错误码
            });
        }
        else if (AppSettings.DbSetting.DbType == DbType.PgSql)
        {
            // PostgreSQL配置
            optionsBuilder.UseNpgsql(connectionString, options =>
            {
                // 配置PostgreSQL重试策略
                // options.EnableRetryOnFailure(
                //     maxRetryCount: 3, // 最多重试3次
                //     maxRetryDelay: TimeSpan.FromSeconds(5), // 重试延迟5秒
                //     errorCodesToAdd: null); // 需要重试的错误码
                //     
                // // 设置命令超时时间
                // options.CommandTimeout(30);
            });
        }
        else if (AppSettings.DbSetting.DbType == DbType.Mssql)
        {
            // SQL Server配置
            optionsBuilder.UseSqlServer(connectionString);
        }
        else if (AppSettings.DbSetting.DbType == DbType.Sqlite)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }

    protected void OnModelCreating(ModelBuilder modelBuilder, Type type)
    {
        try
        {
            // 获取所有项目引用的程序集
            var compilationLibrary = DependencyContext
                .Default?
                .CompileLibraries
                .Where(x => !x.Serviceable && x.Type != "package" && x.Type == "project");

            if (compilationLibrary != null)
                foreach (var compilation in compilationLibrary)
                {
                    // 通过反射加载指定类型的实体
                    // 查找所有继承自指定类型的类，并注册到EF Core中
                    AssemblyLoadContext.Default
                        .LoadFromAssemblyName(new AssemblyName(compilation.Name))
                        .GetTypes().Where(x => x.GetTypeInfo().BaseType != null
                                               && x.BaseType == (type)).ToList()
                        .ForEach(t => { modelBuilder.Entity(t); });
                }

            base.OnModelCreating(modelBuilder);
        }
        catch (Exception ex)
        {
            var mapPath = ($"Log").MapPath();
            FileHelper.WriteFile(
                mapPath,
                $"sysDBlog_{DateTimeExtensions.SystemNow():yyyyMMddHHmmss}.txt",
                ex.Message + ex.StackTrace + ex.Source
            );
        }
    }
}