using Shops.Models;

namespace Shops.Services;

public class UserService
{
    private List<User> users;

    public UserService()
    {
        users = new List<User>();
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }
}