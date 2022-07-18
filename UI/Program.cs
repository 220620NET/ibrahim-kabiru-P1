using Models;
using CustomException;
using Microsoft.Data.SqlClient;
using DataAccess;
 
 
 UserRepository test = new UserRepository();
 //User user1 = new User("ramon", "ger23", "employee");
 //test.AddUser(user1);
      List<User> user = test.GetAllUser();
        foreach (User item in user)
     {
         Console.WriteLine(item);
     }