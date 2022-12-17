using DataAccessLayer.Interface;

namespace DataAccessLayer.Model;

public class Otchet:BaseEntity, IOtchet
{
    public Otchet()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }
    public Worker Owner { get; set; }
    public int Amount { get; set; }
}