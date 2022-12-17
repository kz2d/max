using BuisnesLayer.Services;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;

namespace BuisnesLayer.Frontend;

public class Message
{
    public static Sms? ReadSms(Worker user, Guid uuid)
    {
        var tmp =  MessagesService.ReadSms(uuid);
        AuthService.CheckOwnershipIMessage(user, tmp);
        return tmp;
    }
    
    public static Email? ReadEmail(Worker user,Guid uuid)
    {
        var tmp =  MessagesService.ReadEmail(uuid);
        AuthService.CheckOwnershipIMessage(user, tmp);
        return tmp;
    }
    
    public static Messager? ReadMessager(Worker user,Guid uuid)
    {
        var tmp =  MessagesService.ReadMessager(uuid);
        AuthService.CheckOwnershipIMessage(user, tmp);
        return tmp;
    }
    
    public static void ChangeStatus(Worker user, Guid uuid, Starus st)
    {
        var tmp = MessagesService.ReadMessage(uuid);
        AuthService.CheckOwnershipIMessage(user, tmp);
        if (st <= tmp.Status)
        {
            throw new Exception();
        }
        MessagesService.ChangeStatus(uuid, st);
    }
    
    public static IMessage ReadMessage(Worker user,Guid uuid)
    {
        var tmp =  MessagesService.ReadMessage(uuid);
        AuthService.CheckOwnershipIMessage(user, tmp);
        return tmp;
    }
    
    // public static void UpdateMessage(Worker user, IMessage uuid)
    // {
    //     Auth.CheckOwnershipIMessage(user, uuid);
    //     Messages.UpdateMessage(uuid);
    // }
}