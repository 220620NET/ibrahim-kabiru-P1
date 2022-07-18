using Models;
using DataAccess; 
using CustomExceptions;

namespace Services;
public class AuthService
{
   private readonly IUserRepository _repo;

   public AuthService(IUserRepository repository)
   {
   _repo = repository;

   }
   public User logindetails(string username, string password)
   {  
      User foundUser;
      try
      {
         sat =_repo.GetUserbyUserName(username);
        if (sat.userName == "")
            {
               throw new ResourceNotFoundException();
            }    
          else if(sat.password == password)
             {
                  return sat;
             }
             else
             {
               invalidCredentialsException();
             }
      }
            catch (ResourceNotFoundException)
            {
              throw new ResourceFoundException();
            } 
            catch (invalidCredentialsException)
            {
              throw new invalidCredentialsException();
            }

      }
   }
   /*
   * Register:
   * 1. collect user information
   * 2. In this service method we first need to check if this username exists in our system first
   * 3a. The username is already in the database
   * 4a. Tell the user that the username has already been taken, please try again with a different one
   * 3b. The username isn't in the database (as in, the username is available)
   * 4b. We go ahead and create a new record in our db with the user information
   * 5b. Tell user that the creation was successful
   */
   public User Register(User newUser)
   {
      try
      {
         User check =_repo.GetUserbyUserName(username);
         if (check.username == username)
         {
         throw new UsernameNotAvailableException();
         }
         else
         {
           User user = _repo.createUser(newUser);
         }
         if (User.id > 0)
         {  
            return User;
         }
         else 
         {
            throw new InvalidCredentialsException();
         }
        }
        catch(UserNameNotAvailableException)
        {
            throw new InvalidCredentialsException();
        }
        catch(InvalidCredentialsException)
        {
          throw new InvalidCredentialsException();
        }
      
   }

   /*
   1. Try and get the user by their username
   2a. We don't find the user in db: Tell them invalid credential
   2b. We find user -> then make sure the password matches
   3a. If the username and password matches, they've successfully logged in.
   3b. if password doesn't match, then tell them invalid credential
   */
