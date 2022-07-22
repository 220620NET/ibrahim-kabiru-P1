using Models;
using CustomException;
using DataAccess;

namespace Services;

public class UserService
{
   private readonly IUserRepository _repo;

   public UserService(IUserRepository repository)
   {
     _repo = repository;
   }
 public User GetUserbyUserName(string username)
 {
  try
  {
    return _repo.GetUserbyUserName(username);
  }
   catch(UserNameNotAvailableException)
   {
    throw new UserNameNotAvailableException();
   }
 }
  public User GetUser(int id)
  {
    try
    {
      return _repo.GetUser(id);
    }
     catch (ResourceNotFoundException)
    {
      throw new ResourceNotFoundException();
    
    }
  }
    public List<User> GetAllUser()
    {
      try
      {
        return _repo.GetAllUser();
      }
      catch(UserNameNotAvailableException)
      {
        throw new UserNameNotAvailableException();
      }
    }
  }
 
