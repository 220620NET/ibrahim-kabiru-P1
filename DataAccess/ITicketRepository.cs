using Models;

namespace DataAccess;

public interface ITicketRepository
{
   Tickets GetReimbursmentById(int id);
   List<Tickets> GetReimbursmentByAuthor(string Author);
   List<Tickets> GetReimbursmentByStatus(string Status);
   Tickets CreateReimbursment(Tickets newTickets);
  // Tickets UpdateReimbursmnetString(string val, int id);
   Tickets UpdateReimbursmentAmount(decimal amount, int id);
   List<Tickets> GetAllTicket();

}