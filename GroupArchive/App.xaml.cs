using System.Windows;
using GroupArchive.Services;
using GroupArchive.ViewModels;
using GroupArchive.ViewModels.Pages;
using GroupArchive.ViewModels.Windows;
using GroupArchive.Views.Pages;
using GroupArchive.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Ui;

namespace GroupArchive;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var serviceCollection = ConfigureServices();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private ServiceCollection ConfigureServices()
    {
        ServiceCollection serviceCollection = new();

        // Main window container with navigation
        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<MainWindowViewModel>();

        serviceCollection.AddSingleton<INavService, NavService>();
        serviceCollection.AddSingleton<ISnackbarService, SnackbarService>();
        serviceCollection.AddSingleton<IContentDialogService, ContentDialogService>();

        // All other pages and view models
        serviceCollection.AddTransient<GroupViewerView>();
        serviceCollection.AddTransient<GroupViewerViewModel>();

        serviceCollection.AddTransient<StudentView>();
        serviceCollection.AddTransient<StudentViewModel>();

        return serviceCollection;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}