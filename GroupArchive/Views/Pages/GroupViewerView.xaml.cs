using GroupArchive.ViewModels;

namespace GroupArchive.Views.Pages;

public partial class GroupViewerView
{
    public GroupViewerView(GroupViewerViewModel viewModel)
    {
        DataContext = this;
        ViewModel = viewModel;
        InitializeComponent();
    }

    public GroupViewerViewModel ViewModel { get; }
}