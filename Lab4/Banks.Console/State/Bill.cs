using Banks.Interfaces;

namespace Banks.Console.State;

public class Bill
{
    public static IBillClient Start(IBank bank, IClient client)
    {
        System.Console.WriteLine("Какой счет вы бы хотели создать");
        System.Console.WriteLine("1 - Дебетовый");
        System.Console.WriteLine("2 - Вклад");
        System.Console.WriteLine("3 - Кредитный");

        var num = int.Parse(System.Console.ReadLine() !);

        switch (num)
        {
            case 1:
            {
                var l = bank.CreateDebet(client);
                System.Console.WriteLine($" UUid = {l.Uuid}");
                return l;
            }

            case 2:
            {
                System.Console.WriteLine("введите время вклада");
                var t = int.Parse(System.Console.ReadLine() !);
                var l = bank.CreateVklad(client, t);
                System.Console.WriteLine($" UUid = {l.Uuid}");
                return l;
            }

            case 3:
            {
                var l = bank.CreateCredit(client);
                System.Console.WriteLine($" UUid = {l.Uuid}");
                return l;
            }

            default:
            {
                throw new Exception();
            }
        }
    }
}