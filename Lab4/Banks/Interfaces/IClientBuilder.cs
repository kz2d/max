namespace Banks.Interfaces;

public abstract class ClientBuilder
{
    public abstract ClientBuilder AddName(string name);
    public abstract ClientBuilder AddSurename(string surename);
    public abstract ClientBuilder AddAdress(string adress);
    public abstract ClientBuilder AddPasport(string pasport);
    public abstract IClient GetResult();
}