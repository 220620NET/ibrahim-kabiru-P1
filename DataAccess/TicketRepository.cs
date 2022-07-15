/*using Models;
using CustomException;
using Microsoft.Data.SqlClient;


namespace DataAccess;


public class TicketRepository 
{
    private readonly ConnectionFactory _connectionFactory;
    public TicketRepository(ConnectionFactory factory)
    {
        _connectionFactory = factory;
    }


   public List<Tickets> GetAllTicket()
   {
      List<Tickets> ticket = new List<Tickets>();
      SqlConnection conn = _connectionFactory.GetConnection();

      conn.Open();

       SqlCommand cmd = new SqlCommand("Select * From Ticket", conn);
       SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            ticket.Add(new Tickets
            {
                Id = (int)reader["ticket_id"],
                Author = (int)reader["ticket_author"],
                resolver = (int)reader["ticket_resolver"],
                Description = (string)reader["ticket_description"],
                Status = (string)reader["ticket_status"],
                Money = Convert.ToDecimal((double)reader["ticket_money"]),
                
            });
        }
            reader.Close();
            conn.Close();

           return tickets;

   }
   
    public Tickets GetTicket(string name)
    {
      PokeTrainer foundTrainer;
      SqlConnection conn = _connectionFactory.GetConnection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("Select * From Ticket Where ticket_name = @name", conn);
      
      cmd.Parameters.AddWithValue("@name", name);
      SqlDataReader reader = cmd.ExecuteReader();

      while(reader.Read())
        {
            return new Ticket
            {
                Id = (int)reader["id"],
                Author = (int)reader["author_fk"],
                Resolver = (int)reader["resolver+fk"],
                Description = (string)reader["description"],
                Status = (string)reader["status"],
                Amount = Convert.ToDecimal((double)reader["amount"]),
            };
        }
           throw new RecordNotFoundException("Could not find the ticket with such name");
    }
      
        public Tickets GetTicket(int id)
     {
         throw new NotImplementedException();
     }
  
    
     public Tickets AddTicket(Tickets newTicketToRegister)
     {
        DataSet TicketSet = new DataSet();
        SqlDataAdapter ticketAdapter = new SqlDataAdapter("Select * From Ticket",  _connectionFactory.GetConnection());
        
        ticketAdapter.Fill(TicketSet, "ticketTable");

        DataTable? ticketTable = TicketSet.Tables["ticketTable"];

        if(ticketTable != null)
        {
            DataRow newTickets = ticketTable.NewRow();
            newTickets["ticket_id"] = newTicketToRegister.ID;
            newTickets["ticket_author"] = newTicketToRegister.Author;
            newTickets["ticket_resolver"] = newTicketToRegister.Resolver;
            newTicketss["ticket_description"] = newTicketToRegister.Description;
            newTickets["ticket_status"] = newTicketToRegister.Status;
            newTrainers["ticket_money"] = newTicketToRegister.Money;

             ticketTable.Rows.Add(newTicket);
        
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(ticketAdapter);
            SqlCommand insertCommand = cmdbuilder.GetInsertCommand();

            ticketAdapter.InsertCommand = insertCommand;
        
             ticketAdapter.Update(ticketTable);
        }
             return newTicketToRegister;

     }
     public Tickets UpdateReimbursmentAmount(decimal amount)
  {
    Tickets foundticket;
    SqlConnection conn = _connectionFactory.GetConnection();

    conn.Open();

    SqlCommand cmd = new SqlCommand("Update project1.ticket set amount = @fk ", conn);

    cmd.Parameters.AddWithValue("@fk", amount);

    SqlDataReader reader = cmd.ExecuteReader();

    while(reader.Read())
    {
        return new Ticket
        {
            ID = (int)reader["id"],
            Author = (string)reader["author_fk"],
            Resolver = (string)reader["resolver_fk"],
            Description = (string)reader["description"],
            Status = (string)reader["status"],
            Amount = (decimal)reader["amount"]

        };
    }

    throw new ResourceNotFoundException("Could not find the User with this ");

    reader.Close();
    conn.Close();
    }
   
 
}*/



    

   

