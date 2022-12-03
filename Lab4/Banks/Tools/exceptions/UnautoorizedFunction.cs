namespace Banks.Tools.exceptions;

public class UnautoorizedFunction : Exception
{
    public UnautoorizedFunction() { }

    public UnautoorizedFunction(string message)
        : base(message)
    { }
}