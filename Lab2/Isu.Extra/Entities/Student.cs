using Isu.Extra.Interfaces;
using StudentOld = Isu.Entyties.Student;

namespace Isu.Extra.Entities;

public class Student : StudentOld, IStudentNew
{
    public Student(IGroupNew group, string name)
        : base(group, name)
    {
        Group = group;
        CourseCount = 0;
    }

    public int CourseCount { get; set; }
    public List<IPair> Pairs { get; set; } = new List<IPair>();
    public new IGroupNew Group { get; }
}
