using System.Net.Mime;
using System.Windows;
using GroupArchive.Services;
using GroupArchive.ViewModels.Windows;
using GroupArchive.Views.Pages;
using Wpf.Ui.Appearance;

namespace GroupArchive.Views.Windows;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow
    (
        INavService navService,
        IServiceProvider serviceProvider,
        MainWindowViewModel viewModel
    )
    {
        SystemThemeWatcher.Watch(this);

        DataContext = this;
        ViewModel = viewModel;

        InitializeComponent();

        navService.SetServiceProvider(serviceProvider);
        navService.SetNavigationService(RootFrame.NavigationService);

        navService.Navigate<GroupViewerView>();
        
    }

    public MainWindowViewModel ViewModel { get; }
}