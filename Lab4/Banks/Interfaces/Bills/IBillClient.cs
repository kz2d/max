namespace Banks.Interfaces;

public interface IBillClient
{
    public abstract Guid Uuid { get; }

    public abstract decimal Amount { get; }
    public abstract ITransaction SendMoney(Guid reciver, decimal amount);

    public abstract ITransaction WithdrawCash(decimal amount);

    public abstract ITransaction AddCash(decimal amount);
}