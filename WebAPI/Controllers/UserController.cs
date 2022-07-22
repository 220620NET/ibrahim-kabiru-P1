using Services;
using Models;
using CustomException;
namespace WebAPI.Controllers
{
    public class UserController
    {
        //Dependency Injection
        private readonly UserService _Service;   //Dependency Injection
        public UserController(UserService service)
        {
            _Service = service;
        }
        public IResult GetAllUser()
        {
            try
            {
                List<User> users = _Service.GetAllUser();
                return Results.Accepted("/users", users);
            }
            catch (ResourceNotFoundException)
            {
                return Results.NotFound("There are no users");
            }
           
        }
        public IResult GetUser(int id)
        {

            try
            {
                User user = _Service.GetUser(id);
                return Results.Accepted("/users/id/{id}", user);
            }
            catch(ResourceNotFoundException )
            {
                return Results.BadRequest("NO user has that ID");
            }
            catch (UserNameNotAvailableException)
            {
                return Results.BadRequest("That Id doesn't exist");
            }
        }
        
        public IResult GetUserByUserName(string username)
        {
            try
            {
                User user = _Service.GetUserbyUserName(username);
                return Results.Accepted("/users/name/{username}", user);
            } 
            catch (UserNameNotAvailableException)
            {
                return Results.BadRequest("That username doesn't exist");
            }
        }
    }
}