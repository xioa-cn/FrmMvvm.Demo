namespace ProjectRecord.Common.Utils;

public class FileHelper
{
    public static void WriteFile(string path, string file, string content)
    {
        System.IO.File.WriteAllText(System.IO.Path.Combine(path, file), content);
    }
}