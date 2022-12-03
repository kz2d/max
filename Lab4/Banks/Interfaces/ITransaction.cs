namespace Banks.Interfaces;

public interface ITransaction
{
    public void Start();
    public void Abort();
    public void Complete();
}

public enum State
{
    Initialized,
    Started,
    Completed,
}