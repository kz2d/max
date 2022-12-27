using Shops.exceptions;

namespace Shops;

public class Name
{
    public Name(string name)
    {
        if (name.Length == 0 || name == null)
        {
            throw MathException.IsNullOrEmty();
        }

        NameName = name;
    }

    public string NameName { get; init; }
}