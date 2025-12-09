using ProjectRecord.Models.Db;

namespace ProjectRecord.Models.Configs;

public class AppSettings
{
    public object Logging { get; set; }
    public string AppName { get; set; }
    public DbType DbType { get; set; }
    public string DbConnectString { get; set; }
}