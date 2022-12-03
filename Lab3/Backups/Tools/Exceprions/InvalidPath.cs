namespace Backups.Tools.Exceprions;

public class InvalidPath : Exception
{
    public InvalidPath() { }

    public InvalidPath(string message)
        : base(message)
    {
    }

    public InvalidPath(string message, Exception inner)
        : base(message, inner)
    {
    }
}