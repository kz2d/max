using Shops.Models;

namespace Shops.exceptions;

public class MathException : Exception
{
    public MathException(string message)
        : base(message)
    {
    }

    public static MathException DecreaseBeloweZero() =>
        new MathException($"You to decrease some unsigned below zero");

    public static MathException IsNullOrEmty() =>
        new MathException("Null object or empty string");
}