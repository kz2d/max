namespace Banks.Interfaces;

public interface IBank
{
    public Guid Uuid { get; }
    public decimal Percent { get; }
    public ICentralBank Cb { get; }
    public IBillClient CreateDebet(IClient client);
    public IBillClient CreateVklad(IClient client, int endTime = 0);
    public IBillClient CreateCredit(IClient client);

    public void UpdatePercent(decimal newPercent);
    public void UpdateLimit(decimal newLimit);
}
