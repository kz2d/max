using Shops.exceptions;
using Shops.Models;

namespace Shops.Services;

public class ProductService
{
    private List<Product> _products;

    public ProductService()
    {
        _products = new List<Product>();
    }

    public List<Product> FindProduct(Guid? shopId, Guid? prooductId, Guid? id)
    {
        return _products.Where(s =>
                        (shopId == null || s.ShopId == shopId) &&
                        (prooductId == null || s.ShopId == prooductId) &&
                        (id == null || s.ShopId == id)).ToList();
    }

    public void AddProduct(Product product)
    {
        if (FindProduct(product.ShopId, product.TagId, null).Count != 0)
        {
            throw ShopsException.ProductAlreadyPresented(product);
        }

        _products?.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        if (_products.FindIndex(s => s.Id == product.Id) == -1)
        {
            throw ShopsException.ProductIsNotPresented(product);
        }

        _products[_products.FindIndex(s => s.Id == product.Id)] = product;
    }

    public void Buy(User user, List<(Guid, int)> ids)
    {
        Money amount = BuyOrCount(ids);
        user.WithdrawMoney(amount);
        BuyOrCount(ids, true);
    }

    public void BuyBest(User user, List<(Guid, int)> ids)
    {
        Money amount = BuyOrCountBest(ids);
        user.WithdrawMoney(amount);
        BuyOrCountBest(ids, true);
    }

    private Money BuyOrCount(List<(Guid, int)> ids, bool shouldRemove = false)
    {
        var amount = new Money(0);
        _products.ForEach(s =>
        {
            var find = ids.Find(z => z.Item1 == s.Id);
            if (find.Item2 > s.Amount)
            {
                throw MathException.DecreaseBeloweZero();
            }

            if (shouldRemove)
            {
                s.Amount = s.Amount - find.Item2;
            }

            amount.AddMoney(s.Price.Mul(find.Item2));
        });

        return amount;
    }

    private Money BuyOrCountBest(List<(Guid, int)> ids, bool shouldRemove = false)
    {
        var copy = new List<Product>(_products);
        var amount = new Money(0);

        copy.Sort();
        ids.ForEach(z =>
        {
            while (z.Item2 > 0)
            {
                int i = copy.FindIndex(s => s.TagId == z.Item1 && s.Amount != 0);

                if (i == -1)
                {
                    throw MathException.DecreaseBeloweZero();
                }

                Product find = copy[i];
                int col = Math.Min(find.Amount, z.Item2);

                if (shouldRemove)
                {
                    copy[i].Amount = find.Amount - col;
                }

                amount.AddMoney(find.Price.Mul(col));
                z.Item2 -= col;
            }
        });

        return amount;
    }
}