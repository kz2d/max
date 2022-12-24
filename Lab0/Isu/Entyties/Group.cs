namespace IsuServiceTests.Entyties;

public class Group
{
    public Group(string name) => Name = name;
    public string Name { get; }
    public int CourseNumber { get; set; }
}