using BuisnesLayer.Services;
using BussinesLayer.Test.Services;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;

namespace Banks.Console.State;

public class Documents
{
    public static void Start(Worker w)
    {
        System.Console.WriteLine($"");

        while (true)
        {
            System.Console.WriteLine("Это база");
            System.Console.WriteLine("1 - сгенерировать документ");
            System.Console.WriteLine("2 - изметь статус докумета");
            System.Console.WriteLine("3 - рид документ");
            System.Console.WriteLine("4 - закончить работу с докуметом");

            var num = int.Parse(System.Console.ReadLine() !);

            switch (num)
            {
                case 1:
                {
                    var v=MessageServiceT.createMessage();
                    MessagesService.RegisterMessage(w, v);
                    System.Console.WriteLine($"Otchet: {v.Id}");

                    break;
                }

                case 2:
                {
                    var ui = Guid.Parse(System.Console.ReadLine() !);
                    MessagesService.ChangeStatus(ui, Starus.Complited);
                    break;
                }

                case 3:
                {
                    var ui = Guid.Parse(System.Console.ReadLine() !);
                    System.Console.WriteLine($"Otchet: {MessagesService.ReadMessage(ui).Text}");
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