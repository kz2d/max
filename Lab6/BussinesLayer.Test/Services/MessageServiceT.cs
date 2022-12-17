using System.Data.Common;
using BuisnesLayer.Services;
using BuisnesLayer.Singletons;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace BussinesLayer.Test.Services;

public class MessageServiceT
{
    public static Worker owner = WorkersService.createWorker(new Worker(){Password = "none"}); 
    public static Sms createMessage()
    {
        var m = new Sms() { Text = "lol", Owner = owner };
        DB.getInststance().Sms.Add(m);

        DB.getInststance().SaveChanges();

        return m;
     
    }
}