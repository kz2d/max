namespace Banks.Interfaces;

public interface ICentralBank
{
    public int Time { get; }
    public IBill? Maper(Guid uuid);
    public IBank CreateBank();
    public void RegisterBill(IBill bill);
}