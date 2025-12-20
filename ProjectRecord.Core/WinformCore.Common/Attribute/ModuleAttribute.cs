namespace WinformCore.Common.Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class ModuleAttribute : System.Attribute
{
    public ModuleAttribute(string moduleName)
    {
        ModuleName = moduleName;
    }

    public string ModuleName { get; set; }
}