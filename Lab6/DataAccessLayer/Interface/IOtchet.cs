using DataAccessLayer.Model;

namespace DataAccessLayer.Interface;

public interface IOtchet
{
    public Guid Id { get; set; }
    public Worker Owner { get; set; }
    public int Amount { get; set; }
}