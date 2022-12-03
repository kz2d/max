using Banks.Interfaces;
using Banks.Tools.exceptions;

namespace Banks.Entitys;

public class Credit : Bill
{
    public Credit(IClient client, IBank bank, decimal percent, decimal comision, decimal limit, int endTime)
        : base(client, bank, percent, comision, limit, endTime)
    {
    }

    public override void DecreaseCash(decimal amount)
    {
        if (amount < 0)
        {
            throw new UnautoorizedFunction();
        }

        if (!Client.IsTrusted && Amount - amount - Comision < -Limit)
        {
            throw new UnautoorizedFunction();
        }

        if (Amount - amount >= 0)
        {
            Amount -= amount;
        }
        else
        {
            Amount -= amount - Comision;
        }
    }
}