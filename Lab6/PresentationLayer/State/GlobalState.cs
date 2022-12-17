using Banks.Console.State;
using BuisnesLayer.Services;
using DataAccessLayer.Model;

public class GlobalState
{
    public static void Start()
    {
        var admin = new Worker(){Password = "1"};
        System.Console.WriteLine($"admin uuid = {admin.Id}");
        WorkersService.createWorker(admin);

        while (true)
        {
        System.Console.WriteLine("Это база");
        System.Console.WriteLine("1 - LogIn");

        var num = int.Parse(System.Console.ReadLine() !);

        switch (num)
        {
            case 1:
            {
                var uuid = Guid.Parse(System.Console.ReadLine() !);
                var password = System.Console.ReadLine() !;
                var w = AuthService.TryToAuth(uuid, password);
                if (w is null)
                {
                    System.Console.WriteLine("Try again");
                    break;
                }
                LogIn.Start(w);

                break;
            }
        }
        }
    }
}