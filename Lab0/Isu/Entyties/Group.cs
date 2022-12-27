using Isu.Interfaces;

namespace Isu.Entyties;

public class Group : IGroup
{
    public Group(string name) => Name = name;
    public string Name { get; }
    public int CourseNumber { get; set; }
}