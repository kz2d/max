using Shops.exceptions;

namespace Shops;

public class Money
{
    public Money(decimal money)
    {
        if (money < 0)
        {
            throw MathException.DecreaseBeloweZero();
        }

        Cash = money;
    }

    public decimal Cash { get; private set; }

    public void AddMoney(Money money)
    {
        Cash += money.Cash;
    }

    public void MinusMoney(Money money)
    {
        Cash -= money.Cash;
    }

    public Money Mul(int times)
    {
        return new Money(Cash * times);
    }
}