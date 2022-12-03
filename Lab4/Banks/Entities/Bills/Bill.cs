using Banks.Entitys.Transactions;
using Banks.Interfaces;
using Banks.Tools.exceptions;

namespace Banks.Entitys;

public class Bill : IBill
{
    public Bill(IClient client, IBank bank, decimal percent, decimal comision, decimal limit, int endTime)
    {
        Client = client ?? throw new NullReferenceException();
        Amount = 0;
        Percent = percent;
        Limit = limit;
        Comision = comision;
        EndTime = endTime;
        Bank = bank ?? throw new NullReferenceException();
        Uuid = Guid.NewGuid();
    }

    public decimal Amount { get; protected set; }
    public Guid Uuid { get; }
    public decimal Percent { get; set; }
    public decimal Comision { get; set; }
    public decimal Limit { get; set; }
    public int EndTime { get; set; }
    public IClient Client { get; }
    public List<ITransaction> History { get; } = new List<ITransaction>();
    public IBank Bank { get; }

    public ITransaction SendMoney(Guid reciver, decimal amount)
    {
        return new SendMoney(Bank.Cb.Maper, Uuid, reciver, amount);
    }

    public ITransaction WithdrawCash(decimal amount)
    {
        return new WithdrawMoney(Bank.Cb.Maper, Uuid, amount);
    }

    public ITransaction AddCash(decimal amount)
    {
        return new AddMoney(Bank.Cb.Maper, Uuid, amount);
    }

    public void EncreaseCash(decimal amount)
    {
        if (amount < 0)
        {
            throw new UnautoorizedFunction();
        }

        Amount += amount;
    }

    public void AddTransactionToHistory(ITransaction tr)
    {
        History.Add(tr);
    }

    public virtual void DecreaseCash(decimal amount)
    {
        if (amount < 0 || amount + Comision > Amount || (EndTime != 0 && EndTime < Bank.Cb.Time))
        {
            throw new UnautoorizedFunction();
        }

        Amount -= amount + Comision;
    }

    public void ApplyPercent()
    {
        if (Amount < 0)
        {
            return;
        }

        Amount += Amount * Percent;
    }
}