using shop.Domain;
using System.Collections.Generic;

namespace shop.IDataAccess;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUserById(int id);
    IEnumerable<User> GetAllUsers();
    void UpdateUser(User user);
    void DeleteUser(int id);
}