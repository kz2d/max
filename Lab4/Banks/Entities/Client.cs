using Banks.Interfaces;

namespace Banks.Entitys;

public class Client : IClient
{
    private string? _adress;
    private string? _pasport;
    public Client(string name, string surename, string? adress, string? pasport)
    {
        Name = name;
        Surename = surename;
        Adress = adress;
        Pasport = pasport;
    }

    public string Name { get; }
    public string Surename { get; }

    public string? Adress
    {
        get => _adress;
        set
        {
            _adress = value;
            CheckTrust();
        }
    }

    public string? Pasport
    {
        get => _pasport;
        set
        {
            _pasport = value;
            CheckTrust();
        }
    }

    public bool IsTrusted { get; private set; }

    public void Notify()
    {
        Console.WriteLine(Name + " notified!");
    }

    private void CheckTrust()
    {
        IsTrusted = Adress is not null && Pasport is not null;
    }
}