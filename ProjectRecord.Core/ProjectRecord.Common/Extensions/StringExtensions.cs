namespace ProjectRecord.Common.Extensions;

public static class StringExtensions
{
    public static string MapPath(this string path)
    {
        var result = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

        if (!System.IO.Directory.Exists(result))
        {
            System.IO.Directory.CreateDirectory(result);
        }

        return result;
    }
}