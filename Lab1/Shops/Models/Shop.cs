namespace Shops.Models;

public class Shop
{
    public Shop(Name name, Name adres)
    {
        Name = name;
        Adres = adres;
        Id = Guid.NewGuid();
        Balance = new Money(123);
    }

    public Name Name { get; init; }
    public Name Adres { get; init; }
    public Guid Id { get; init; }

    // For show only because we doesnt implemented trust by that moment
    public Money Balance { get; private set; }

    public void TransferToShop(Money money)
    {
        Balance.AddMoney(money);
    }
}