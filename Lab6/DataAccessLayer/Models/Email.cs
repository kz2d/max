using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Model;

public class Email: BaseEntity, IEmail
{
    public Email()
    {
       Id = Guid.NewGuid();
    }
        
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Starus Status { get; set; }
    public Worker Owner { get; set; }
    public Worker? Employee { get; set; }
}