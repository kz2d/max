using Isu.Extra.Interfaces;
using GroupOld = Isu.Entyties.Group;
namespace Isu.Extra.Entities;

public class Group : GroupOld, IGroupNew
{
    public Group(string name, Megafacultet megafacultet)
        : base(name)
    {
        Name = name;
        Megafacultet = megafacultet;
        Schedule = new List<Pair>();
    }

    public List<IStudentNew> Student { get; set; } = new List<IStudentNew>();
    public List<IStream> Streams { get; set; } = new List<IStream>();

    public new string Name { get; set; }
    public Megafacultet Megafacultet { get; set; }
    public List<Pair> Schedule { get; set; }

    public void AddStream(IStream st)
    {
        Streams.Add(st);
    }

    public void AddStudent(IStudentNew student)
    {
        Student.Add(student);
        foreach (var st in Streams)
        {
            student.Pairs.AddRange(st.Schedule);
        }
    }
}