using System.Windows;
using System.Windows.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace GroupArchive.Services;

public class NavService : INavService
{
    private NavigationService? _navigationService;
    private IServiceProvider? _serviceProvider;

    public void SetServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void SetNavigationService(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public NavigationService? GetNavigationService()
    {
        return _navigationService;
    }

    public void Navigate<TContent>() where TContent : FrameworkElement
    {
        if (_serviceProvider is null)
            throw new NullReferenceException("ServiceProvider is null");
        if (_navigationService is null)
            throw new NullReferenceException("NavigationService is null");

        var content = _serviceProvider.GetRequiredService<TContent>();

        _navigationService.Navigate(content);
    }

    public bool CanGoBack => _navigationService.CanGoBack;

    public void GoBack()
    {
        if (CanGoBack) _navigationService.GoBack();
    }

    public bool CanGoForward => _navigationService.CanGoForward;

    public void GoForward()
    {
        if (CanGoBack) _navigationService.GoForward();
    }
}