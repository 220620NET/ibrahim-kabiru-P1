using Models;

namespace DataAccess;

public interface IUserRepository
{
  List<User> GetAllUser();
  User GetUser(int id);
  User GetUserbyUserName(string username);
  User AddUser(User newUserToRegister);
}