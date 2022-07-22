using Models;

namespace DataAccess;

public interface ITicketRepository
{
   Tickets GetReimbursementById(int id);
   List<Tickets> GetReimbursementByAuthor(string Author);
   List<Tickets> GetReimbursementByStatus(string Status);
   Tickets CreateReimbursement(Tickets newTickets);
  // Tickets UpdateReimbursmnetString(string val, int id);
   Tickets UpdateReimbursementAmount(decimal amount, int id);
   List<Tickets> GetAllTicket();

}