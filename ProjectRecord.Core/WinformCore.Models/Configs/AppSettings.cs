using WinformCore.Models.Db;

namespace WinformCore.Models.Configs;

public class AppSettings
{
    public object Logging { get; set; }
    public string AppName { get; set; }
    public DbType DbType { get; set; }
    public string DbConnectString { get; set; }
}