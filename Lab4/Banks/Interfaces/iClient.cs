namespace Banks.Interfaces;

public interface IClient
{
    public string Name { get; }
    public string Surename { get; }
    public string? Adress { get; set; }
    public string? Pasport { get; set; }
    public bool IsTrusted { get; }
    public void Notify();
}