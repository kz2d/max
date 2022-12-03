using Banks.Interfaces;

namespace Banks.Console.State;

public class Transaction
{
    public static void Start(ITransaction tr)
    {
        tr.Start();
        System.Console.WriteLine("Вы уверены?(yes)");
        if (System.Console.ReadLine() == "yes")
        {
            System.Console.WriteLine("Транзакция завершена");
            tr.Complete();
        }
        else
        {
            System.Console.WriteLine("Транзакция преращена");
            tr.Abort();
        }
    }
}