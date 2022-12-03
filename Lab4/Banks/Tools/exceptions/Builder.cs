namespace Banks.Tools.exceptions;

public class BuilderException : Exception
{
    public BuilderException() { }

    public BuilderException(string message)
        : base(message)
    { }
}