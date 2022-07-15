using Models;
using CustomException;
using Microsoft.Data.SqlClient;


namespace DataAccess;


public class UserRepository 
{

  private readonly ConnectionFactory _connectionFactory;

   public UserRepository()
 {
   _connectionFactory = ConnectionFactory.GetInstance();
 }
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

 /*public User GetUser(string name)
  {
      User foundUser;
      SqlConnection conn = _connectionFactory.GetConnection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("Select * From project.users Where username = @name", conn);

      cmd.Parameters.AddWithValue("@name", name);
      SqlDataReader reader = cmd.ExecuteReader();

       while(reader.Read())
        {
         return new User
         {
         Id = (int)reader["trainer_id"],
             Name = (string)reader["trainer_name"],
             password = (string)reader["trainer_password"],
             role = (string)reader["trainer_role"],

         };

          }
           
           
     throw new ResourceNotFoundException("Could not find the user  with such name");
    
    }

public User GetUser(int id)
 {
 throw new NotImplementedException();
 } 

 public User AddUser(User newUserToRegister)
    {
        DataSet UserSet = new DataSet();

        SqlDataAdapter userAdapter = new SqlDataAdapter("Select * project.users",  _connectionFactory.GetConnection());

        userAdapter.Fill(UserSet, "UserTable");


        DataTable? UserTable = UserSet.Tables["UserTable"];

        if(UserTable != null)
        {
            DataRow newUser = UserTable.NewRow();
            newUser["user_name"] = newUserToRegister.Name;
            newUser["user_password"] = newUserToRegister.Password;
            newUser["use_role"] = newUserToRegister.Role;
            newUser["User_id"] = newUserToRegister.Id;

            UserTable.Rows.Add(newUser);

            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(userAdapter);
            SqlCommand insertCommand = cmdbuilder.GetInsertCommand();

        
            userAdapter.InsertCommand = insertCommand;

          
            userAdapter.Update(UserTable);
        }
        return newTUserToRegister;
    }*/
}

    
    
  
