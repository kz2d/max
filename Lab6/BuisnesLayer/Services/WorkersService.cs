using BuisnesLayer.Singletons;
using DataAccessLayer.Model;

namespace BuisnesLayer.Services;

public class WorkersService
{
    public static Worker createWorker(Worker w)
    {
        DB.getInststance().Worker.Add(w);
        if (w.Boss is not null)
        {
            DB.getInststance().Worker.FirstOrDefault(x => x.Id == w.Boss.Id)?.Employee.Add(w);
        }
        DB.getInststance().SaveChanges();
        return w;
    }
}