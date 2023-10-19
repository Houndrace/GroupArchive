namespace GroupArchive.Models;

public class Student
{
    public Student(string name, Group group)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Group = group ?? throw new ArgumentNullException(nameof(group));
    }

    public string Name { get; set; }
    public Group Group { get; set; }
}