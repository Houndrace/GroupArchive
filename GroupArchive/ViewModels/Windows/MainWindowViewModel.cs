using CommunityToolkit.Mvvm.ComponentModel;

namespace GroupArchive.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private string _applicationTitle = "Архив студенчески групп";
}