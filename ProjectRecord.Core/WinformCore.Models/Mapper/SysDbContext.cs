using Microsoft.EntityFrameworkCore;
using WinformCore.Models.Configs;
using WinformCore.Models.Db;

namespace WinformCore.Models.Mapper;

public class SysDbContext : EfDataContext
{
    protected override string ConnectionString => AppSettings.DbConnectString;
    protected override AppSettings AppSettings { get; }


    public SysDbContext(AppSettings appSettings) : base()
    {
        AppSettings = appSettings;
    }

    public SysDbContext(DbContextOptions<EfDataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.UseDbType(optionsBuilder, ConnectionString);
        //默认禁用实体跟踪
        //optionsBuilder = optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder, typeof(BaseSysEntity));
    }
}