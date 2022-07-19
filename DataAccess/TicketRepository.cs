using Models;
using CustomException;
using Microsoft.Data.SqlClient;


namespace DataAccess;


public class TicketRepository: ITicketRepository
{
    private readonly ConnectionFactory _connectionFactory;

    public TicketRepository()
    {
        _connectionFactory = ConnectionFactory.GetInstance();
    }


   public List<Tickets> GetAllTicket()
   {
      List<Tickets> ticket = new List<Tickets>();
      SqlConnection conn = _connectionFactory.GetConnection();

      conn.Open();

       SqlCommand cmd = new SqlCommand("Select * From project.tickets", conn);
       SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            ticket.Add(new Tickets((int)reader[0],(string)reader[1],(string)reader[2],(string)reader[3],(string)reader[4],(decimal)reader[5]));
           
        }
            reader.Close();
            conn.Close();

           return ticket;

   }
   
    public List<Tickets> GetReimbursmentByAuthor(string author)
    {
      
      Tickets foundTickets;
      SqlConnection conn = _connectionFactory.GetConnection();
      conn.Open();

      //SqlCommand command = new SqlCommand("insert into project.tickets (author, resolver, description, status, amount) values (@author, @resolver, @description, @status, @amount)",  _connectionFactory.GetConnection());
      SqlCommand command = new SqlCommand ("Select * From project.tickets where author = @author", conn);
      command.Parameters.AddWithValue("@author", author);
      SqlDataReader reader = command.ExecuteReader();
      List<Tickets> tickets = new List<Tickets>();
      while(reader.Read())
        {
            tickets.Add (new Tickets   //return new Tickets
            {
             ID = (int)reader["ID"],
             Author = (string)reader["Author"],
             resolver = (string)reader["resolver"],
             Description = (string)reader["Description"],
             Status = (string)reader["Status"],
             Amount = Convert.ToDecimal((double)reader["Amount"]),
            });
        }
           throw new ResourceNotFoundException("Could not find the ticket with such name");
    }
      
        public Tickets GetReimbursmentById(int id)
     {
         throw new ResourceNotFoundException();
     }
      public List<Tickets>  GetReimbursmentByStatus(string status)
    {
      Tickets foundTickets;
      SqlConnection conn = _connectionFactory.GetConnection();
      conn.Open();

     SqlCommand command = new SqlCommand("Select * From project.tickets where status = @status", conn);
     //("insert into project.tickets (author, resolver, description, status, amount) values (@author, @resolver, @description, @status, @amount)",  _connectionFactory.GetConnection());
      command.Parameters.AddWithValue("@status", status);
      SqlDataReader reader = command.ExecuteReader();
      List<Tickets> tickets = new();
      while(reader.Read())
        {
             tickets.Add (new Tickets   //return new Tickets
            {
             ID = (int)reader["ID"],
             Author = (string)reader["Author"],
             resolver = (string)reader["resolver"],
             Description = (string)reader["Description"],
             Status = (string)reader["Status"],
             Amount = Convert.ToDecimal((double)reader["Amount"]),
            }  
            );
        }
           throw new ResourceNotFoundException("Could not find the ticket with such name");
    }
    
     public Tickets CreateReimbursment(Tickets newTicketsToRegister)
     {
        Tickets TicketsSet = new Tickets();
        SqlConnection conn = _connectionFactory.GetConnection();
        
         // SqlDataAdapter ticketAdapter = new SqlDataAdapter("Select * From project.tickets",  _connectionFactory.GetConnection());
        SqlCommand command = new SqlCommand("insert into project.tickets (tickets_id, author, resolver, description,status, amount) values (@tickets_id, @author, @resolver,@description, @status, @amount)",  _connectionFactory.GetConnection());
        command.Parameters.AddWithValue("@tickets_id", newTicketsToRegister.ID); 
        command.Parameters.AddWithValue("@Author", newTicketsToRegister.Author);
        command.Parameters.AddWithValue("@resolver", newTicketsToRegister.resolver); 
        command.Parameters.AddWithValue("@description", newTicketsToRegister.Description); 
        command.Parameters.AddWithValue("@status", newTicketsToRegister.Status); 
        command.Parameters.AddWithValue("@amount", newTicketsToRegister.Amount);
      
        try
        {
             conn.Open();
             int tax = command.ExecuteNonQuery();
             conn.Close();
             //----
             if (tax != 0)
             {
                if (newTicketsToRegister.Author != null)
                {
                    return CreateReimbursment(newTicketsToRegister);
                }
                else
                {
                    throw new UserNameNotAvailableException();
                }
            }
            else
            {
                throw new UserNameNotAvailableException();
            }
            //----
        }
        catch (UserNameNotAvailableException)
        {
            throw new UserNameNotAvailableException();
        } 
        

     }
         
    public Tickets UpdateReimbursmentAmount(decimal amount, int id)
   {
    Tickets foundticket;
    SqlConnection conn = _connectionFactory.GetConnection();

    conn.Open();

    SqlCommand cmd = new SqlCommand("Update project.tickets set amount = @fk ", conn);

    cmd.Parameters.AddWithValue("@fk", amount);

    SqlDataReader reader = cmd.ExecuteReader();

    while(reader.Read())
    {
        return new Tickets
        {
            ID = (int)reader["id"],
            Author = (string)reader["author_fk"],
            resolver = (string)reader["resolver_fk"],
            Description = (string)reader["description"],
            Status = (string)reader["status"],
            Amount = (decimal)reader["amount"]

        };
    }

    throw new ResourceNotFoundException("Could not find the User with this ");

    reader.Close();
    conn.Close();
    }
   
 
}



    

   

