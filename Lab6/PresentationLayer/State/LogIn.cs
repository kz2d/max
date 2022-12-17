using BuisnesLayer.Services;
using DataAccessLayer.Model;

namespace Banks.Console.State;

public class LogIn
{
    public static void Start(Worker w)
    {
        System.Console.WriteLine($"");

        while (true)
        {
        System.Console.WriteLine("Это база");
        System.Console.WriteLine("1 - создать подчиненого");
        System.Console.WriteLine("2 - сгенерировать отчет");
        System.Console.WriteLine("3 - работать с документами");
        System.Console.WriteLine("4 - Выйти");

        var num = int.Parse(System.Console.ReadLine() !);

        switch (num)
        {
            case 1:
            {
                var ww = new Worker(){Boss = w, Password = Guid.NewGuid().ToString()};
                WorkersService.createWorker(ww);
                System.Console.WriteLine($"Worker: {ww}");
                break;
            }

            case 2:
            {
                var o = OtchetService.createOtchet(w);
                System.Console.WriteLine($"Otchet: {o}");
                break;
            }

            case 3:
            {
               Documents.Start(w);

                break;
            }

            case 4:
            {
                return;
                break;
            }
        }
        }
    }
}