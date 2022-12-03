using Banks.Entitys;
using Banks.Interfaces;
using Banks.Tools.exceptions;

namespace Banks.Builders;

public class ClientBuilder : Interfaces.ClientBuilder
{
    private string? _name;
    private string? _surename;
    private string? _adress;
    private string? _pasport;
    public override ClientBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public override ClientBuilder AddSurename(string surename)
    {
        _surename = surename;
        return this;
    }

    public override ClientBuilder AddAdress(string adress)
    {
        _adress = adress;
        return this;
    }

    public override ClientBuilder AddPasport(string pasport)
    {
        _pasport = pasport;
        return this;
    }

    public override Client GetResult()
    {
        if (_name is null || _surename is null)
        {
            throw new BuilderException();
        }

        var l = new Client(_name, _surename, _adress, _pasport);
        _name = null;
        _surename = null;
        _adress = null;
        _pasport = null;
        return l;
    }
}