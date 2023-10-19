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
    private readonly INavService _navService;
    [ObservableProperty] private Group? _selectedGroup;
    [ObservableProperty] private string _viewTitle = "Список групп";


    public GroupViewerViewModel(INavService navService)
    {
        _navService = navService;

        InitializeData();
    }

    public ObservableCollection<Group> GroupCollection { get; private set; } = null!;
    public ObservableCollection<ObservableCollection<Student>> GroupStudentCollection { get; private set; } = null!;

    private void InitializeData()
    {
        GroupCollection = new ObservableCollection<Group>
        {
            new(new DateOnly(2011, 1, 1), "Информатика", 1, 1),
            new(new DateOnly(2012, 1, 1), "Математика", 2, 2),
            new(new DateOnly(2013, 1, 1), "Физика", 3, 3),
            new(new DateOnly(2014, 1, 1), "Технология", 4, 4),
            new(new DateOnly(2011, 1, 1), "Прикладная информатика", 5, 1)
        };
    }

    [RelayCommand]
    private void OnGroupCardDoubleClick()
    {
        if (SelectedGroup is null) return;

        _navService.Navigate<StudentView>();
        Messenger.Send(new ValueChangedMessage<Group>(SelectedGroup));
    }
}