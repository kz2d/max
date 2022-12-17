using DataAccessLayer.Model;

namespace DataAccessLayer.Interface;

public enum Starus
{
    New = 0,
    Recieved = 1,
    Complited = 2
}
public interface IMessage
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Starus Status { get; set; }
    public Worker Owner { get; set; }
    public Worker? Employee { get; set; }
}