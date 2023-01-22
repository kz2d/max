namespace Isu.Extra.Interfaces;

public interface IPair
{
    public TimeSpan Time { get; set; }
    public ITeacher Teacher { get; set; }
    public string Audience { get; set; }
}