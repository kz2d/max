namespace Banks.Tools.exceptions;

public class WrongTransactionSequence : Exception
{
    public WrongTransactionSequence() { }

    public WrongTransactionSequence(string message)
        : base(message)
    { }
}