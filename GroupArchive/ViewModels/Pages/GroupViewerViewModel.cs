using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using GroupArchive.Models;
using GroupArchive.Services;
using GroupArchive.Views.Pages;

namespace GroupArchive.ViewModels;

public partial class GroupViewerViewModel : ObservableRecipient
{
    private readonly IFileService _fileService;
    private readonly INavService _navService;
    [ObservableProperty] private Group? _selectedGroup;
    [ObservableProperty] private string _viewTitle = "Список групп";


    public GroupViewerViewModel(INavService navService, IFileService fileService)
    {
        _navService = navService;
        _fileService = fileService;

        InitializeData();
    }

    public ObservableCollection<Group> GroupCollection { get; private set; } = null!;
    public ObservableCollection<ObservableCollection<Student>> GroupStudentCollection { get; private set; } = null!;

    private void InitializeData()
    {
        GroupCollection = new ObservableCollection<Group>
        {
            new("2011", "Информатика", 1, 1),
            new("2012", "Математика", 2, 2),
            new("2013", "Физика", 3, 3),
            new("2014", "Технология", 4, 4),
            new("2011", "Прикладная информатика", 5, 1)
        };
    }

    [RelayCommand]
    private void OnGroupCardDoubleClick()
    {
        if (SelectedGroup is null) return;

        _navService.Navigate<StudentView>();
        Messenger.Send(new ValueChangedMessage<Group>(SelectedGroup));
    }

    [RelayCommand]
    private void OnLoadButtonClick()
    {
        _fileService.LoadFile<ObservableCollection<Student>>("data.xml");

        var loadedStudentCollection = _fileService.Content as ObservableCollection<Student>;

        if (loadedStudentCollection is null)
            return;

        _navService.Navigate<StudentView>();
        Messenger.Send(new ValueChangedMessage<ObservableCollection<Student>>(loadedStudentCollection));
    }
}