using shop.Domain;
using System.Collections.Generic;

namespace shop.IBusinessLogic;

public interface IUserLogic
{
    void CreateUser(User user);
    User GetUser(int id);
    IEnumerable<User> GetAllUsers();
    void UpdateUser(User user);
    void DeleteUser(int id);
}