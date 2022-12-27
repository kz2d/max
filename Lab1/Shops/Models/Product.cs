using Shops.exceptions;

namespace Shops.Models;

public class Product
{
    private int _amount = 0;

    public Product(Name name, Money price, Guid tagId, int amount, Guid shopId)
    {
        Name = name;
        Price = price;
        Amount = amount;
        ShopId = shopId;
        TagId = tagId;
        Id = Guid.NewGuid();
    }

    public Name Name { get; init; }
    public Money Price { get; set; }
    public Guid ShopId { get; init; }
    public Guid TagId { get; init; }
    public Guid Id { get; init; }

    public int Amount
    {
        get
        {
            return _amount;
        }

        set
        {
            if (value < 0)
            {
                throw MathException.DecreaseBeloweZero();
            }

            _amount = value;
        }
    }
}