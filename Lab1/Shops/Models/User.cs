namespace Shops.Models;

public class User
{
    public User(Name name, Money money)
    {
        Name = name;
        Money = money;
    }

    public Name Name { get; init; }
    public Money Money { get; private set; }

    public void AddMoney(Money money)
    {
        Money.AddMoney(money);
    }

    public void WithdrawMoney(Money money)
    {
        Money.MinusMoney(money);
    }
}