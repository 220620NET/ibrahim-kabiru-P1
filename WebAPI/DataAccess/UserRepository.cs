using Models;
using CustomException;
using Microsoft.Data.SqlClient;


namespace DataAccess;


public class UserRepository: IUserRepository 
{

  private readonly ConnectionFactory _connectionFactory;

   public UserRepository()
 {
   _connectionFactory = ConnectionFactory.GetInstance(File.ReadAllText("../DataAccess/connectionString.txt"));
 }
 /*public UserRepository(ConnectionFactory factory)
        {
            _connectionFactory = factory;
        }*/
 public List<User> GetAllUser()
 {
   List<User> user = new List<User>();
   SqlConnection conn = _connectionFactory.GetConnection();
   
   conn.Open();

   SqlCommand cmd = new SqlCommand ("Select * From project.users", conn);
   SqlDataReader reader =  cmd.ExecuteReader();


    while(reader.Read())
        {
             user.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3]));

        }
        reader.Close();
        conn.Close();


        return user;

 }

 public User GetUserbyUserName(string username)
  {
      User foundUser;
      SqlConnection conn = _connectionFactory.GetConnection();
      conn.Open();

      SqlCommand command = new SqlCommand ("Select * From project.users where username = @username", conn);
      //("insert into project.users (username, password, user_role) values (@username, @password, @user_role)",  _connectionFactory.GetConnection());

      command.Parameters.AddWithValue("@username", username);

      SqlDataReader reader = command.ExecuteReader();

       while(reader.Read())
        {
         return new User
         {
           userID = (int)reader["userID"],
           userName = (string)reader["userName"],
           Password = (string)reader["password"],
           role = (string)reader["role"],
        
         };

        }

     throw new ResourceNotFoundException("Could not find the user with such name");
    
    }

public User GetUser(int id)
 {
throw new NotImplementedException();
 } 
 public User AddUser(User newUserToRegister)
    {
       User UserSet = new User();  
        
        SqlConnection conn = _connectionFactory.GetConnection();
        SqlCommand command = new SqlCommand("insert into project.users (username, password, user_role) values (@username, @password, @user_role)",  _connectionFactory.GetConnection());
        command.Parameters.AddWithValue("@username", newUserToRegister.userName); 
        command.Parameters.AddWithValue("@password", newUserToRegister.Password); 
        command.Parameters.AddWithValue("@user_role", newUserToRegister.role);
        try
             {
                conn.Open();
                int sat = command.ExecuteNonQuery();
                conn.Close();
            
                if (sat != 0)
                {
                    if (newUserToRegister.userName != null)
                    {
                        return newUserToRegister;
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
             }
            catch (UserNameNotAvailableException)
            {
                throw new UserNameNotAvailableException();
            } 
           
    }
    
}



    
    
  
