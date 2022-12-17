using BuisnesLayer.Singletons;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;

namespace BuisnesLayer.Services;

public class MessagesService
{
    public static Sms? ReadSms(Guid uuid)
    {
        return DB.getInststance().Sms.FirstOrDefault(x => x.Id == uuid);
    }
    
    public static Email? ReadEmail(Guid uuid)
    {
        return DB.getInststance().Email.FirstOrDefault(x => x.Id == uuid);
    }
    
    public static Messager? ReadMessager(Guid uuid)
    {
        return DB.getInststance().Messager.FirstOrDefault(x => x.Id == uuid);
    }
    
    public static void ChangeStatus(Guid uuid, Starus st)
    {
        ReadMessage(uuid).Status = st;
        DB.getInststance().SaveChanges();
    }
    
    public static IMessage? ReadMessage(Guid uuid)
    {
        return DB.getInststance().Sms.FirstOrDefault(x => x.Id == uuid) as IMessage ??
               DB.getInststance().Email.FirstOrDefault(x => x.Id == uuid) as IMessage ??
               DB.getInststance().Messager.FirstOrDefault(x => x.Id == uuid);
    }
    
    public static void RegisterMessage(Worker w, IMessage m)
    {
        ReadMessage(m.Id).Employee = w;
        DB.getInststance().SaveChanges();
    }
    
    public static List<IMessage> ReadMessage(Worker w)
    {
        var tmp = DB.getInststance().Sms.Where(x => x.Employee.Id == w.Id) as IQueryable<IMessage>; 
        return tmp.Concat(
               DB.getInststance().Email.Where(x => x.Employee.Id == w.Id) as IQueryable<IMessage>).Concat(
               DB.getInststance().Messager.Where(x => x.Employee.Id == w.Id) as IQueryable<IMessage>).ToList();
    }
    
    public static void UpdateMessage(IMessage uuid)
    {
        DB.getInststance().SaveChanges();
    }
}