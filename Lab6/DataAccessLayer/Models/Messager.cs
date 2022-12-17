using DataAccessLayer.Interface;

namespace DataAccessLayer.Model;

public class Messager:BaseEntity, IMessager
{
    public Messager()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Starus Status { get; set; }
    public Worker Owner { get; set; }
    public Worker? Employee { get; set; }
}