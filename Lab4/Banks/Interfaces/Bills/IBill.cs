namespace Banks.Interfaces;

public interface IBill : IBillClient
{
    public IClient Client { get; }
    public void DecreaseCash(decimal amount);
    public void ApplyPercent();
    public void EncreaseCash(decimal amount);
    public void AddTransactionToHistory(ITransaction tr);
}