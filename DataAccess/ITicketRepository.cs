using Models;

namespace DataAccess;

public interface ITicketRepository
{
   List<Tickets> GetReimbursmentById(int id);
   List<Tickets> GetReimbursmentByAuthor(string Author);
   List<Tickets> GetReimbursmentByStatus(string Status);
   Tickets CreateReimbursment(User newTicket);
   Tickets UpdateReimbursmnetString(string val, int id);
   Tickets UpdaterReimbursmentAmount(decimal amount, int id);

}