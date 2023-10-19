using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using GroupArchive.Models;
using GroupArchive.Services;

namespace GroupArchive.ViewModels.Pages;

public partial class StudentViewModel : ObservableRecipient, IRecipient<ValueChangedMessage<Group>>
{
    private readonly INavService _navService;
    [ObservableProperty] private Group? _receivedGroup;
    [ObservableProperty] private string _viewTitle = "Список студентов группы ";
    [ObservableProperty] private ObservableCollection<Student>? _studentCollection;

    public StudentViewModel(INavService navService)
    {
        _navService = navService;
        IsActive = true;

        InitializeDate();
    }

    public ObservableCollection<Group> GroupCollection { get; private set; } = null!;
    public ObservableCollection<ObservableCollection<Student>> GroupStudentCollection { get; private set; } = null!;

    public void Receive(ValueChangedMessage<Group> message)
    {
        ReceivedGroup = message.Value;

        ViewTitle += ReceivedGroup.Number;

        StudentCollection = GroupStudentCollection.First(collection =>
            collection.Any(student => student.Group.Specialization == ReceivedGroup.Specialization));
    }


    private void InitializeDate()
    {
        GroupCollection = new ObservableCollection<Group>
        {
            new(new DateOnly(2011, 1, 1), "Информатика", 1, 1),
            new(new DateOnly(2012, 1, 1), "Математика", 2, 2),
            new(new DateOnly(2013, 1, 1), "Физика", 3, 3),
            new(new DateOnly(2014, 1, 1), "Технология", 4, 4),
            new(new DateOnly(2011, 1, 1), "Прикладная информатика", 5, 1)
        };

        GroupStudentCollection = new ObservableCollection<ObservableCollection<Student>>
        {
            new()
            {
                new Student("Иванов Иван Иванович", GroupCollection[0]),
                new Student("Петров Петр Петрович", GroupCollection[0]),
                new Student("Сидорова Елена Владимировна", GroupCollection[0]),
                new Student("Козлов Алексей Андреевич", GroupCollection[0]),
                new Student("Смирнова Ольга Александровна", GroupCollection[0]),
                new Student("Морозов Дмитрий Викторович", GroupCollection[0]),
                new Student("Волкова Татьяна Андреевна", GroupCollection[0]),
                new Student("Николаева Марина Сергеевна", GroupCollection[0]),
                new Student("Григорьев Сергей Васильевич", GroupCollection[0]),
                new Student("Кузнецов Андрей Алексеевич", GroupCollection[0])
            },
            new()
            {
                new Student("Краснова Анна Игоревна", GroupCollection[1]),
                new Student("Беляев Артем Александрович", GroupCollection[1]),
                new Student("Лебедев Владимир Васильевич", GroupCollection[1]),
                new Student("Соколова Ирина Викторовна", GroupCollection[1]),
                new Student("Медведев Павел Дмитриевич", GroupCollection[1]),
                new Student("Романов Станислав Андреевич", GroupCollection[1]),
                new Student("Горбунова Наталья Петровна", GroupCollection[1]),
                new Student("Андреева Ольга Андреевна", GroupCollection[1]),
                new Student("Попов Андрей Сергеевич", GroupCollection[1])
            },
            new()
            {
                new Student("Федорова Екатерина Андреевна", GroupCollection[2]),
                new Student("Жуков Александр Сергеевич", GroupCollection[2]),
                new Student("Гаврилов Иван Александрович", GroupCollection[2]),
                new Student("Карпова Елена Павловна", GroupCollection[2]),
                new Student("Орлова Анастасия Александровна", GroupCollection[2]),
                new Student("Баранов Антон Андреевич", GroupCollection[2]),
                new Student("Степанов Денис Игоревич", GroupCollection[2]),
                new Student("Королев Вячеслав Сергеевич", GroupCollection[2]),
                new Student("Дмитриев Максим Валентинович", GroupCollection[2]),
                new Student("Назарова Мария Степановна", GroupCollection[2])
            },
            new()
            {
                new Student("Гусев Сергей Андреевич", GroupCollection[3]),
                new Student("Ларина Екатерина Александровна", GroupCollection[3]),
                new Student("Захаров Артур Викторович", GroupCollection[3]),
                new Student("Сорокина Татьяна Ивановна", GroupCollection[3]),
                new Student("Яковлев Александр Сергеевич", GroupCollection[3]),
                new Student("Комаров Андрей Александрович", GroupCollection[3]),
                new Student("Титов Антон Валерьевич", GroupCollection[3]),
                new Student("Воронова Анна Васильевна", GroupCollection[3])
            },
            new()
            {
                new("Михайлова Ольга Игоревна", GroupCollection[4]),
                new("Васильев Игорь Андреевич", GroupCollection[4]),
                new("Петухова Мария Владимировна", GroupCollection[4]),
                new("Чернов Алексей Сергеевич", GroupCollection[4]),
                new("Горшкова Елена Александровна", GroupCollection[4]),
                new("Кудрявцев Дмитрий Валентинович", GroupCollection[4]),
                new("Филиппов Андрей Петрович", GroupCollection[4]),
                new("Зайцев Антон Иванович", GroupCollection[4]),
                new("Лебедева Анна Александровна", GroupCollection[4]),
                new("Комиссаров Александр Вячеславович", GroupCollection[4])
            }
        };
    }

    [RelayCommand]
    private void OnBackButtonClick()
    {
        _navService.GoBack();
    }
}