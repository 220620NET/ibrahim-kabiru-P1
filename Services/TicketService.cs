using Models;
using DataAccess;

namespace Services;
public class TickerService
{
    private readonly TicketRepository _repo;

     public TicketService(TicketRepository repo)
     {
       _repo = repo;
     }
   public List<Tickets> GetAllTickets()
   {
      return _repo.GetAllTickets();
   }
}
