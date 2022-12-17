namespace DataAccessLayer.Interface;

public interface IWorker<Worker>
    where Worker : IWorker<Worker>
{
    public Guid Id { get; set; }

    public ICollection<Worker> Employee { get; }
    public Worker? Boss { get; set; }
    public string Password { get; set; }
}