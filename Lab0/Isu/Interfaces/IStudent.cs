namespace Isu.Interfaces;

public interface IStudent
{
    public int Id { get; }
    public IGroup Group { get; set; }
    public string Name { get; }
}