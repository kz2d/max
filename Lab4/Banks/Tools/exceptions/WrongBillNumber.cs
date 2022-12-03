namespace Banks.Tools.exceptions;

public class WrongBillNumber : Exception
{
    public WrongBillNumber() { }

    public WrongBillNumber(string message)
        : base(message)
    { }
}