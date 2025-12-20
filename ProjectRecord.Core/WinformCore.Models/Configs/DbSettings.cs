using WinformCore.Models.Db;

namespace WinformCore.Models.Configs;

public class DbSettings
{
    public DbType DbType { get; set; }

    public required string DbConnectString { get; set; }
}