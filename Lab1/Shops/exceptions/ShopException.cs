using Shops.Models;

namespace Shops.exceptions;

public class ShopsException : Exception
{
    public ShopsException(string message)
        : base(message)
    {
    }

    public static ShopsException ProductIsNotPresented(Product product) =>
        new ShopsException($"Product {product.Name} is not presented at shop {product.ShopId}");

    public static ShopsException ProductAlreadyPresented(Product product) =>
        new ShopsException($"Product {product.Name} is presented at shop {product.ShopId}");
}
