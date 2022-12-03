using Banks.Interfaces;
using Banks.Tools.exceptions;

namespace Banks.Entitys;

public class BillClient : IBillClient
{
    private IBill _proxy;

    public BillClient(IBill bill)
    {
        _proxy = bill ?? throw new NullReferenceException();
    }

    public Guid Uuid => _proxy.Uuid;
    public decimal Amount
    {
        get => _proxy.Amount;
        protected set => throw new UnautoorizedFunction();
    }

    public ITransaction SendMoney(Guid reciver, decimal amount)
    {
        return _proxy.SendMoney(reciver, amount);
    }

    public ITransaction WithdrawCash(decimal amount)
    {
        return _proxy.WithdrawCash(amount);
    }

    public ITransaction AddCash(decimal amount)
    {
        return _proxy.AddCash(amount);
    }
}