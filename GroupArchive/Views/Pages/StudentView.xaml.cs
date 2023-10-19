using System.Windows.Controls;
using GroupArchive.ViewModels.Pages;

namespace GroupArchive.Views.Pages;

public partial class StudentView : Page
{
    public StudentView(StudentViewModel viewModel)
    {
        DataContext = this;
        ViewModel = viewModel;
        InitializeComponent();
    }

    public StudentViewModel ViewModel { get; }
}