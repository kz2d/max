using Banks.Interfaces;

namespace Banks.Console.State;

public class BillTransfer
{
    public static void Start(IBillClient client)
    {
        while (true)
        {
            System.Console.WriteLine("Управление операциями");
            System.Console.WriteLine("1 - перевести");
            System.Console.WriteLine("2 - положить деньги на счет");
            System.Console.WriteLine("3 - снять деньги с счета");
            System.Console.WriteLine("4 - баланс");
            System.Console.WriteLine("5 - Выход");
            var num = int.Parse(System.Console.ReadLine() !);

            switch (num)
            {
                case 1:
                {
                    System.Console.WriteLine("Ведите кому");
                    var to = Guid.Parse(System.Console.ReadLine() !);

                    System.Console.WriteLine("Ведите сколько");
                    var amount = decimal.Parse(System.Console.ReadLine() !);

                    var tr = client.SendMoney(to, amount);
                    Transaction.Start(tr);
                    break;
                }

                case 2:
                {
                    System.Console.WriteLine("Ведите сколько");
                    var amount = decimal.Parse(System.Console.ReadLine() !);

                    var tr = client.AddCash(amount);
                    Transaction.Start(tr);
                    break;
                }

                case 3:
                {
                    System.Console.WriteLine("Ведите сколько");
                    var amount = decimal.Parse(System.Console.ReadLine() !);

                    var tr = client.WithdrawCash(amount);
                    Transaction.Start(tr);
                    break;
                }

                case 4:
                {
                    System.Console.WriteLine($"{client.Amount}");
                    break;
                }

                case 5:
                {
                    System.Console.WriteLine("Exit");
                    return;
                }
            }
        }
    }
}