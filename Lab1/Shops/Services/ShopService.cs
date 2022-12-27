using Shops.exceptions;
using Shops.Models;

namespace Shops.Services;

public class ShopService
{
    private List<Shop> shops;
    private List<Product> products;

    public ShopService()
    {
        shops = new List<Shop>();
        products = new List<Product>();
    }

    public Shop AddShop(Shop shop)
    {
        shops.Add(shop);
        return shop;
    }

    public Product RegisterProduct(Product product)
    {
        products.Add(product);
        return product;
    }

    public void Buy(Product product, User user)
    {
        if (product.Amount <= 0)
        {
            throw MathException.DecreaseBeloweZero();
        }

        user.WithdrawMoney(product.Price);
        product.Amount -= 1;
    }
}