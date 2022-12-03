using Banks.Entitys;
using Banks.Interfaces;

namespace Banks.Console.State;

public class GlobalState
{
    public static void Start()
    {
        var cb = new CentralBank((centralBank) => CreateBank.Start(centralBank));
        var users = new List<IClient>();
        var banks = new List<IBank>();
        IClient? activeUser = null;
        IBillClient? activeBill = null;
        IBank? activeBank = null;

        while (true)
        {
        System.Console.WriteLine("Это база");
        System.Console.WriteLine("1 - создать клиента");
        System.Console.WriteLine("2 - выбрать клиента");
        System.Console.WriteLine("3 - создать банк");
        System.Console.WriteLine("4 - выбрать банк");
        System.Console.WriteLine("5 - Создать счет");
        System.Console.WriteLine("6 - Выбрать счет");
        System.Console.WriteLine("7 - Начать операции со счетом");
        System.Console.WriteLine("8 - Ускорить время");

        var num = int.Parse(System.Console.ReadLine() !);

        switch (num)
        {
            case 1:
            {
                users.Add(CreateClient.Start());
                if (activeUser is null)
                {
                    activeUser = users[0];
                    System.Console.WriteLine($"now active {activeUser!.Name}");
                }

                break;
            }

            case 2:
            {
                System.Console.Write(users.Select((cl, i) => $"{i} - {cl.Name} {cl.Surename}\n").Aggregate((s1, s2) => s1 + s2));
                System.Console.WriteLine("Ведите номер");

                var l = int.Parse(System.Console.ReadLine() !);

                activeUser = users[l];
                System.Console.WriteLine($"now active {activeUser!.Name}");
                break;
            }

            case 3:
            {
                banks.Add(cb.CreateBank());
                if (activeBank is null)
                {
                    activeBank = banks[0];
                    System.Console.WriteLine($"now active {activeBank.Uuid}");
                }

                break;
            }

            case 4:
            {
                System.Console.Write(banks.Select((cl, i) => $"{i} - {cl.Uuid}  Persent = {cl.Percent}\n").Aggregate((s1, s2) => s1 + s2));
                System.Console.WriteLine("Ведите номер");
                var l = int.Parse(System.Console.ReadLine() !);

                activeUser = users[l];
                System.Console.WriteLine($"now active {activeBank!.Uuid}");
                break;
            }

            case 5:
            {
                if (activeBank is null || activeUser is null)
                {
                    throw new Exception();
                }

                activeBill = State.Bill.Start(activeBank, activeUser);
                break;
            }

            case 6:
            {
                System.Console.Write(cb.Bills.Select((cl, i) => $"{i} - {cl.Uuid}  Cash = {cl.Amount}\n").Aggregate((s1, s2) => s1 + s2));
                System.Console.WriteLine("Ведите номер");
                var l = int.Parse(System.Console.ReadLine() !);

                activeUser = users[l];
                System.Console.WriteLine($"now active {activeBank!.Uuid}");
                break;
            }

            case 7:
            {
                if (activeBill is null)
                {
                    throw new Exception();
                }

                BillTransfer.Start(activeBill);
                break;
            }

            case 8:
            {
                System.Console.WriteLine("Сколько дней промотать вперед");
                var l = int.Parse(System.Console.ReadLine() !);

                cb.SpeedUpTime(l);
                break;
            }
        }
        }
    }
}