using Models;
using CustomException;
using DataAccess;

namespace Services;
public class TicketService
{
    private readonly ITicketRepository _repo;

     public TicketService(ITicketRepository repository)
     {
       _repo = repository;
     }
    public List<Tickets> GetReimbursementByAuthor(string author)
    {
     try
     {
       return _repo.GetReimbursementByAuthor(author);
     }
     catch(UserNameNotAvailableException)
     {
       throw new UserNameNotAvailableException();
     }

    }
    public Tickets GetTickets(int id)
    { 
      try
      {
        return _repo.GetReimbursementById(id);
       }
      catch(ResourceNotFoundException)
      {
        throw new ResourceNotFoundException();
      }
     }
   public List<Tickets> GetAllTickets()
   {
    try
     {
      return  _repo.GetAllTicket();
     }
     catch(ResourceNotFoundException)
     {
      throw new ResourceNotFoundException();
     }
    
   }
  public Tickets  SubmitTickets(Tickets newTicketsToRegister)
  {  
    try
    {
      return _repo.CreateReimbursement(newTicketsToRegister);
    }
    catch(ResourceNotFoundException)
    {
      throw new ResourceNotFoundException();
    }
  }
 public  List<Tickets> GetReimbursementsbyStatus(string status)
 {
  try
  {
   return _repo.GetReimbursementByStatus(status);
   }
   catch(InvalidCredentialsException)
   {
    throw new InvalidCredentialsException();
   }
 }
public Tickets UpdateReimbursementAmount(decimal amount, int id)
{
  try
  {
    return _repo.UpdateReimbursementAmount(amount, id);
  }
  catch (ResourceNotFoundException)
  {
    throw new ResourceNotFoundException();
  }
}

}
