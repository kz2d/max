using Banks.Interfaces;

namespace Banks.Entitys;

public class Bank : IBank
{
    public Bank(ICentralBank cb, decimal percent = 0, decimal commision = 0, decimal limit = 0)
    {
        Cb = cb;
        Uuid = Guid.NewGuid();
        Bills = new List<IBill>();
        Percent = percent;
        Commision = percent;
        Limit = limit;
    }

    public ICentralBank Cb { get; }

    public Guid Uuid { get; }
    public decimal Percent { get; private set; }
    public decimal Commision { get; private set; }
    public decimal Limit { get; private set; }

    private List<IBill> Bills { get; }

    public IBillClient CreateDebet(IClient client)
    {
        var l = new Bill(client, this, Percent, 0, Limit, 0);
        Bills.Add(l);
        Cb.RegisterBill(l);
        return new BillClient(l);
    }

    public IBillClient CreateVklad(IClient client, int endTime = 0)
    {
        var l = new Bill(client, this, Percent, 0, Limit, endTime);
        Bills.Add(l);
        Cb.RegisterBill(l);
        return new BillClient(l);
    }

    public IBillClient CreateCredit(IClient client)
    {
        var l = new Credit(client, this, Percent, Commision, Limit, 0);
        Bills.Add(l);
        Cb.RegisterBill(l);
        return new BillClient(l);
    }

    public void UpdatePercent(decimal newPercent)
    {
        Percent = newPercent;
        Bills.ForEach(bill => bill.Client.Notify());
    }

    public void UpdateLimit(decimal newLimit)
    {
        Limit = newLimit;
        Bills.ForEach(bill => bill.Client.Notify());
    }
}