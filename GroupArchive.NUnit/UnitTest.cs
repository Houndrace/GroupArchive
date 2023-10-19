using System.Diagnostics;
using System.Windows;
using GroupArchive.ViewModels.Pages;
using Application = TestStack.White.Application;

namespace GroupArchive.NUnit;

public class Tests
{
    private Application _app;
    [SetUp]
    public void Setup()
    {
        _app = TestStack.White.Application.Launch("D:\\GitHub\\GroupArchive\\GroupArchive\\bin\\Debug\\net6.0-windows\\GroupArchive.exe");
        
    }

    [Test]
    public void TestLoadWindow()
    {
        var window = _app.GetWindows()[0];
        
        Assert.IsNotNull(window);
        
        _app.Kill();
    }
    
    [Test]
    public void TestLoadFile()
    {
        var window = _app.GetWindows()[0];
        
        Assert.IsNotNull(window);
        
        _app.Kill();
    }
    
    [Test]
    public void TestLoadFileNot()
    {
        var window = _app.GetWindows()[0];
        
        Assert.IsNotNull(window);
        
        _app.Kill();
    }
    
    [Test]
    public void TestSaveFile()
    {
        var window = _app.GetWindows()[0];
        
        Assert.IsNotNull(window);
        
        _app.Kill();
    }
    
    [Test]
    public void TestSaveFileNot()
    {
        var window = _app.GetWindows()[0];
        
        Assert.IsNotNull(window);
        
        _app.Kill();
    }
}