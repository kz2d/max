using Banks.Entitys;
using Banks.Interfaces;

namespace Banks.Console.State;

public class CreateBank
{
    public static IBank Start(ICentralBank cb)
    {
        System.Console.WriteLine("Ведите процент на остаток");
        decimal percent = decimal.Parse(System.Console.ReadLine() !);

        System.Console.WriteLine("Ведите комисию при уходе в минус, кредитный счет");
        decimal commision = decimal.Parse(System.Console.ReadLine() !);

        System.Console.WriteLine("Ведите лимит по уходу в минус для не верефицированных пользователей");
        decimal limit = decimal.Parse(System.Console.ReadLine() !);
        var b = new Bank(cb, percent, commision, limit);
        System.Console.WriteLine($" UUid = {b.Uuid}");
        return b;
    }
}