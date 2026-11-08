namespace cVeraS5.Utils;

internal static class FileAccessHelper
{
    public static string GetLocalFilePath(string filename) => Path.Combine(FileSystem.AppDataDirectory, filename);
}
