using System.IO;
using System.Xml.Serialization;

namespace GroupArchive.Services.File;

public class FileService : IFileService
{
    private XmlSerializer? _xmlSerializer;

    public object? Content { get; private set; }

    public bool LoadFile<T>(string path) where T : class
    {
        _xmlSerializer = new XmlSerializer(typeof(T));


        using (var fs = new FileStream(path, FileMode.Open))
        {
            Content = _xmlSerializer.Deserialize(fs);
        }
        
        if (Content is null)
            return false;

        return true;
    }

    public bool SaveFile(string path, object content)
    {
        var contentType = content.GetType();
        _xmlSerializer = new XmlSerializer(contentType);

        using (var fs = new FileStream(path, FileMode.Create))
        {
            _xmlSerializer.Serialize(fs, content);
        }

        return true;
    }
}