using Models;
using DataAccess;

namespace Services;

public class UserService
{
   private readonly UserRepository _repo;

   public UserService(UserRepository repo)
   {
     _repo = repo;
   }
 public List<User> GetAllUser()
 {
   return _repo.GetAllUser();
 }
} 