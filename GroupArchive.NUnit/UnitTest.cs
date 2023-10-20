using GroupArchive.Services.File;
using TestStack.White;

namespace GroupArchive.NUnit;

public class Tests
{
    private const string AppLocation =
        "D:\\GitHub\\GroupArchive\\GroupArchive\\bin\\Debug\\net6.0-windows\\GroupArchive.exe";

    private const string DataLocation = "D:\\GitHub\\GroupArchive\\GroupArchive\\bin\\Debug\\net6.0-windows\\data.xaml";
    private Application _app;
    private FileService _fileService;

    [SetUp]
    public void Setup()
    {
        _fileService = new FileService();
    }

    [Test]
    public void TestLoadWindow()
    {
        _app = Application.Launch(AppLocation);
        var window = _app.GetWindows()[0];

        Assert.IsNotNull(window);

        _app.Kill();
    }

    [Test]
    public void TestLoadFile()
    {
        Assert.IsTrue(_fileService.LoadFile<string>(DataLocation));
    } 

    [Test]
    public void TestLoadFileNot()
    {
        var code = new TestDelegate(() =>
        {
            _fileService.LoadFile<Type>("не существующий путь");
        });
        
        Assert.Catch(typeof(FileNotFoundException), code);
    }

    [Test]
    public void TestSaveFile()
    {
        var testData = "test";
        Assert.IsTrue(_fileService.SaveFile(DataLocation, testData));
    }

    [Test]
    public void TestSaveFileNot()
    {
        var testData = "test";
        Assert.IsTrue(_fileService.SaveFile("fasdfs.ffff", testData));
    }
}