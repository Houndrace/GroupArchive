using System.Windows;
using System.Windows.Navigation;

namespace GroupArchive.Services;

public interface INavService
{
    bool CanGoBack { get; }

    bool CanGoForward { get; }
    void SetServiceProvider(IServiceProvider serviceProvider);

    void SetNavigationService(NavigationService navigationService);

    NavigationService? GetNavigationService();

    void Navigate<T>() where T : FrameworkElement;

    void GoBack();

    void GoForward();
}