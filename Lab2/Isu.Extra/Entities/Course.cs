using Isu.Extra.Interfaces;

namespace Isu.Extra.Entities;

public class Course : ICourse
{
    public Course(string name, Megafacultet megafacultet)
    {
        Name = name;
        Megafacultet = megafacultet;
    }

    public string Name { get; set; }
    public Megafacultet Megafacultet { get; set; }
    public List<IStream> Streams { get; set; } = new List<IStream>();

    public void AddStream(Stream st)
    {
        Streams.Add(st);
    }
}