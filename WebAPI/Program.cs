using Services;
using Models;
using DataAccess;
using WebAPI.Controllers;
using CustomException;


var builder = WebApplication.CreateBuilder(args);
//depedency injection container handled by ASP.NET Core
// Different ways to add dependencies: Singleton, Scoped and Transcient 

// Singleton objects are the same for every request and share througtout the entire lifetime of the application
// Scoped objects are the same for a given request but differ accross each new request. (share during request lifecycle)
// Transient objects are always different. The transient operation id value is different int the index model and in the middleware (it generated everytime it needs )

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("ERSDB")));
builder.Services.AddTransient<AuthService>();          //Adding a dependency to AuthServices.
builder.Services.AddTransient<UserService>();          //I may not need services references w/controllers?
builder.Services.AddTransient<TicketService>();
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<TicketController>();

builder.Configuration.GetConnectionString("ERSDB");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Hi Sam!");
/* The curl braces are the route parameter
app.MapGet("/greet/{name}", (string name) => {
   return $"Hi {name}!"; });
// Querry parameter these are key value pairs you pass in with your url after the question mark(:)
app.MapGet("/greet", (string name) => {
    return $"hello {name}"; });

 app.MapGet("/users", (UserService service) => 
 {
    return service.GetAllUser();
});*/

/*  Authorization Endpoints
 *  
 *  /register will will send information to the url to allow the user to register a new user.
 *  /login is to allow the user to login in using the information exsitence in the server.
 */


app.MapPost("/register", (User user, AuthController controller) =>controller.Register(user));
app.MapPost("/login", (User user, AuthController controller) => controller.logindetails(user));

//app.MapPut("/reset", (Users user, AuthController controller) => controller.Reset(user));
//app.MapPut("/payroll", (Users user, AuthController controller) => controller.PayRollChange(user));

 //User Endpoints
//users can be entered into the url bar to read all users in the database.
//users/id/{id} can be entered into the url to read the specific user 
 //users/name/{username} can be entered into the url to resd a specific name.

app.MapGet("/user/id/{id}", (int id, UserController controller) => controller.GetUser(id));
app.MapGet("/users/name/{username}", (string username, UserController controller) => controller.GetUserByUserName(username));
app.MapGet("/user", (UserController controller) =>controller.GetAllUser());

/*Ticket Endpoints

 * /Submit is to send the information to the server ticket controller and sent to services to create new one 
 *  /process is to convert the information into a Ticket controller and  then sent to Services to be Updated
 *  /tickets/author/{author} can be entered in the url bar and will return the  reading  list of tickets that user has made or an error if that user doesn't exist
 *  /tickets/id/{ticketNum} can be entered in the url bar and will return the reading of the specified ticket or error if that ticket doesn't exist
 *  /tickets/status/{status} can be entered in the url bar and will return the reading  list of tickets that have the specified status
 */
app.MapPost("/submit", (Tickets newTicket, TicketController controller) => controller.Submit(newTicket));
app.MapPost("/process", (decimal amount, int id, TicketController controller) => controller.Process(amount, id));
app.MapGet("/tickets/author/{author}", (string author, TicketController controller) => controller.GetTicketByAuthor(author));
app.MapGet("/tickets/id/{ticketNum}", (int ticketNum, TicketController controller) => controller.GetTicketByTicketNum(ticketNum));
app.MapGet("/tickets/status/{status}", (string status, TicketController controller) => controller.GetTicketByStatus(status));
app.MapGet("/tickets", (TicketController controller) => controller.GetAllTickets());

app.Run();




/*Http : hypertext transfer protocol
is use to communicate between machines over the web.
some of methods of http are : get use to get resorces over the web, post uses to create a new resources, put is to update , delete
is to delete over the web.
 What is a database?
A database is an organized collection of structured information.

*/







 





