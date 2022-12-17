using DataAccessLayer;

namespace BuisnesLayer.Singletons;

public class DB
{
    private static readonly DatabaseContext instance = new DatabaseContext();

    public static DatabaseContext getInststance()
    {
        return instance;
    }
}