using Banks.Interfaces;

namespace Banks.Entitys;

public class CentralBank : ICentralBank
{
    private Func<ICentralBank, IBank> _bankBuilder;

    public CentralBank(Func<ICentralBank, IBank> bankBuilder)
    {
        _bankBuilder = bankBuilder;
        Bills = new List<IBill>();
    }

    public List<IBill> Bills { get; }
    public int Time { get; private set; } = 0;

    public IBill? Maper(Guid uuid)
    {
        return Bills.Find(bill => bill.Uuid == uuid);
    }

    public IBank CreateBank()
    {
        return _bankBuilder(this);
    }

    public void RegisterBill(IBill bill)
    {
        Bills.Add(bill);
    }

    public void SpeedUpTime(int time)
    {
        while (time != 0)
        {
            Bills.ForEach(bill => bill.ApplyPercent());
            time--;
        }
    }
}