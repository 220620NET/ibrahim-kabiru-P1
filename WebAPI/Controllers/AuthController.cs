 using Services;
using Models;
using CustomException;
namespace WebAPI.Controllers;

    public class AuthController
    {
        //Dependency injection
        private readonly AuthService _authService;
        private readonly UserService _userService;
        public AuthController(AuthService service, UserService userService)
        {
            _authService = service;
            _userService = userService;   
        }
       
        public IResult Register(User user)
        {
            try
            {
                user.userName = user.userName != null ? user.userName : "";
                _authService.Register(user);
                user =_userService.GetUserbyUserName(user.userName);
                return Results.Created("/register", user);
            }
            catch (UserNameNotAvailableException)
            {
                return Results.BadRequest("That username is not allowed or has already been taken. Please try another.");
            }
        }
       
        public IResult logindetails(User user)
        {
            try
            {
                user.userName = user.userName != null ? user.userName : "";
                user.Password = user.Password != null ? user.Password : "";
                user = _authService.logindetails(user.userName, user.Password);
                return Results.Ok(user);
            }
            catch (InvalidCredentialsException)
            {
                return Results.Unauthorized();
            }
            catch (ResourceNotFoundException)
            {
                return Results.Unauthorized();
            }
        }
    }
