namespace GroupArchive;

public interface IFileService
{
    object? Content { get; }

    bool LoadFile<T>(string path) where T : class;

    bool SaveFile(string path, object content);
}