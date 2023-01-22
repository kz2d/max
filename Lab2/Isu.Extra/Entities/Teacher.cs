using Isu.Extra.Interfaces;

namespace Isu.Extra.Entities;

public class Teacher : ITeacher
{
    public Teacher(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }

    public string Name { get; }
    public Guid Id { get; }
}