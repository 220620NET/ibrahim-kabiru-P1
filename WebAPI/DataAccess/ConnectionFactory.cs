using Models;
using Microsoft.Data.SqlClient;
public class ConnectionFactory
{
   private static ConnectionFactory? _instance;
    //private static string _connectionString = File.ReadAllText("../DataAccess/connectionString.txt"); //readonly

    //private ConnectionFactory() {}
    private readonly string _connectionString;
   private ConnectionFactory(string connectionString)  //
        {                                               //
            _connectionString = connectionString;      //
        }                                            // 
    
    //public static ConnectionFactory GetInstance()
   public static ConnectionFactory GetInstance(string connectionString) //
    
    {
        if(_instance == null)
        {
           // _instance = new ConnectionFactory();
            _instance = new ConnectionFactory(connectionString); //
        }
        return _instance;
    }
    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}