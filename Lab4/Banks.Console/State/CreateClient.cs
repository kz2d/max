using Banks.Builders;
using Banks.Entitys;
using Banks.Interfaces;
using ClientBuilder = Banks.Builders.ClientBuilder;

namespace Banks.Console.State;

public class CreateClient
{
    public static IClient Start()
    {
        var builder = new ClientBuilder();

        while (true)
        {
            System.Console.WriteLine("Создание клиента");
            System.Console.WriteLine("1 - Имя");
            System.Console.WriteLine("2 - Фамилия");
            System.Console.WriteLine("3 - Адрес");
            System.Console.WriteLine("4 - Паспорт");
            System.Console.WriteLine("5 - Завершить");
            var num = int.Parse(System.Console.ReadLine() !);

            switch (num)
            {
                case 1:
                {
                    System.Console.WriteLine("Ведите имя");
                    var str = System.Console.ReadLine() !;
                    builder.AddName(str);
                    break;
                }

                case 2:
                {
                    System.Console.WriteLine("Ведите Фамилию");
                    var str = System.Console.ReadLine() !;
                    builder.AddSurename(str);
                    break;
                }

                case 3:
                {
                    System.Console.WriteLine("Ведите Адрес");
                    var str = System.Console.ReadLine() !;
                    builder.AddAdress(str);
                    break;
                }

                case 4:
                {
                    System.Console.WriteLine("Ведите Паспорт");
                    var str = System.Console.ReadLine() !;
                    builder.AddPasport(str);
                    break;
                }

                case 5:
                {
                    System.Console.WriteLine("Ведите имя");
                    return builder.GetResult();
                }
            }
        }
    }
}