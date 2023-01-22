using Isu.Extra.Interfaces;

namespace Isu.Extra.Entities;

public class Pair : IPair
{
    public Pair(TimeSpan time, ITeacher teacher, string audience)
    {
        Time = time;
        Teacher = teacher;
        Audience = audience;
    }

    public TimeSpan Time { get; set; }
    public ITeacher Teacher { get; set; }
    public string Audience { get; set; }
}