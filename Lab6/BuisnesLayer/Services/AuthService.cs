using BuisnesLayer.Singletons;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;

namespace BuisnesLayer.Services;

public class AuthService
{
    public static Worker? TryToAuth(Guid uuid, string password)
    {
        return DB.getInststance().Worker.FirstOrDefault(x => x.Id == uuid && x.Password == password);
    }
    
    public static bool CheckOwnershipIMessage(Worker w, IMessage m)
    {
        if (m.Owner.Boss is null)
        {
            return true;
        }
        
        if (m.Employee.Id == m.Id || m.Owner.Id == m.Id)
        {
            return true;
        }

        var tmp = m.Owner;
        while (tmp.Boss is not null)
        {
            if ( tmp.Boss.Id == m.Id)
            {
                return true;
            }

            tmp = tmp.Boss;
        }

 

        throw new Exception();
    }
}