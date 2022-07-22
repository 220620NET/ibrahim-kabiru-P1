using Services;
using Models;
using CustomException;
namespace WebAPI.Controllers
{
    public class TicketController
    {
        // Dependency Injection
        private readonly TicketService _Service;
        public TicketController(TicketService service)
        {
            _Service = service;
        }
        
        public IResult Submit(Tickets newTicketsToRegister)
        {
            try
            {
                 Tickets ticket = _Service.SubmitTickets(newTicketsToRegister); 
                return Results.Accepted("/submit", _Service.SubmitTickets(newTicketsToRegister));
            }
            catch (ResourceNotFoundException)
            {
                return Results.Conflict("We could not submit that ticket.");
            }
            catch (UserNameNotAvailableException)
            {
                return Results.Conflict("There is no user with that ID.");
            }
        }
        
        public IResult Process(decimal amount, int id)
        {
            try
            {

                Tickets ticket = _Service.UpdateReimbursementAmount(amount, id); //bool all
                //if (ticket) // all
                {
                    return Results.Accepted("/process", _Service.GetTickets(ticket.ID));
                }
                return Results.BadRequest($"That Ticket has already updated {_Service.GetTickets(ticket.ID).Amount}.");
            }
            catch (ResourceNotFoundException)
            {
                return Results.Conflict("We could not update that ticket.");
            }
            catch (UserNameNotAvailableException)
            {
                return Results.Conflict("There is no user with that ID.");
            }
        }
        
        public IResult GetTicketByTicketNum(int ticketNum)
        {
            try
            {
                Tickets ticket = _Service.GetTickets(ticketNum);
                return Results.Accepted("/tickets/id/{id}", ticket);
            }
            catch (ResourceNotFoundException)
            {
                return Results.BadRequest("That ticket has not been create yet");
            }
        }
        
        public IResult GetTicketByAuthor(string  author)
        {
            try
            {
                List<Tickets> tickets = _Service.GetReimbursementByAuthor(author);
                return Results.Accepted("/tickets/author/{author}", tickets);
            }
            catch (ResourceNotFoundException)
            {
                return Results.BadRequest("That user hasn't made any tickets.");
            }
        }
        public IResult GetTicketByStatus(string status)
        {
            //int s= new Tickets().StateToNum(state);
            try
            {
                List<Tickets> tickets = _Service.GetReimbursementsbyStatus(status);
                if (tickets.Count == 0)
                {
                    throw new ResourceNotFoundException();
                }
                return Results.Accepted("/tickets/status/{status}", tickets);
            }
            catch (ResourceNotFoundException)
            {
                //return Results.BadRequest($"There are no tickets that are {new Tickets().NumToStatus(status)}.");
                 return Results.BadRequest($"There are no tickets that are {new Tickets()}");
            }
        }
        public IResult GetAllTickets()
        {
            try
            {
                List<Tickets> GetAll = _Service.GetAllTickets();
                return Results.Accepted("/tickets", GetAll);
            }
            catch (ResourceNotFoundException)
            {
                return Results.BadRequest("There are no tickets");
            }
        }
    }
}