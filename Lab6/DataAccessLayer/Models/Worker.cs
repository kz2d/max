using DataAccessLayer.Interface;

namespace DataAccessLayer.Model;

public class Worker:BaseEntity, IWorker<Worker>
{
    public Worker()
    {
        Id = Guid.NewGuid();
        Employee = new List<Worker>();
    }
    
    public Guid Id { get; set; }
    public ICollection<Worker> Employee { get; }
    public Worker? Boss { get; set; }
    public string Password { get; set; }
}