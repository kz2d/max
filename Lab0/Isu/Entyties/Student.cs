using Isu.Interfaces;

namespace Isu.Entyties;

public class Student : IStudent
{
    private static int _nextId = 0;

    public Student(IGroup group, string name)
    {
        Id = GetNextId();
        Group = group;
        Name = name;
    }

    public int Id { get; }
    public IGroup Group { get; set; }
    public string Name { get; }

    private static int GetNextId()
    {
        return ++_nextId;
    }
}