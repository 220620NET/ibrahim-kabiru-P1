using Models;
using CustomException;
using DataAccess;

namespace Services;
public class TicketService
{
    private readonly ITicketRepository _repo;

     public TicketService(TicketRepository repository)
     {
       _repo = repository;
     }
    public List<Tickets> GetReimbursmentByAuthor(string author)
    {
     try
     {
       return _repo.GetReimbursmentByAuthor(author);
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
        return _repo.GetReimbursmentById(id);
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
  public Tickets  AddTickets(Tickets newTicketsToRegister)
  {  
    try
    {
      return _repo.CreateReimbursment(newTicketsToRegister);
    }
    catch(ResourceNotFoundException)
    {
      throw new ResourceNotFoundException();
    }
  }
 public  List<Tickets> GetReimbursmentsbyStatus(string status)
 {
  try
  {
   return _repo.GetReimbursmentByStatus(status);
   }
   catch(InvalidCredentialsException)
   {
    throw new InvalidCredentialsException();
   }
 }
public Tickets UpdateReimbursmentAmount(decimal amount, int id)
{
  try
  {
    return _repo.UpdateReimbursmentAmount(amount, id);
  }
  catch (ResourceNotFoundException)
  {
    throw new ResourceNotFoundException();
  }
}

}
