using WinformCore.Models.Db;

namespace WinformCore.Models.Configs;

public class AppSettings
{
    public required object Logging { get; set; }
    public required string AppName { get; set; }
    public required DbSettings DbSetting { get; set; }
}