using BuisnesLayer.Singletons;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;

namespace BuisnesLayer.Services;

public class OtchetService
{
    public static DataAccessLayer.Model.Otchet createOtchet(Worker boss)
    {

        var t = new List<IMessage>();
        foreach (var i in DB.getInststance().Worker
                     .Where(x => x.Boss == boss)
                     .Select(x => MessagesService.ReadMessage(x)))
        {
            t = t.Concat(i).ToList();
        }
        t = t.Where(x => x.Status == Starus.Complited).ToList();

        var o = new Otchet();
        o.Owner = boss;
        o.Amount = t.Count();

        DB.getInststance().Otchet.Add(o);
        DB.getInststance().SaveChanges();
        return o;
    }
    
    public static DataAccessLayer.Model.Otchet? readOtchet(Guid uuid)
    {
        return DB.getInststance().Otchet.FirstOrDefault(x => x.Id == uuid);
    }
}