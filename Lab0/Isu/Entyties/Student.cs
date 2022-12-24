namespace IsuServiceTests.Entyties;

public class Student
{
    private static int _nextId = 0;

    public Student(Group group, string name)
    {
        Id = GetNextId();
        Group = group;
        Name = name;
    }

    public int Id { get; }
    public Group Group { get; set; }
    public string Name { get; }

    private static int GetNextId()
    {
        return ++_nextId;
    }
}