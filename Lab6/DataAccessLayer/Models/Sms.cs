using DataAccessLayer.Interface;

namespace DataAccessLayer.Model;

public class Sms:BaseEntity, ISMS
{
    public Sms()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Starus Status { get; set; }
    public Worker Owner { get; set; }
    public Worker? Employee { get; set; }
}