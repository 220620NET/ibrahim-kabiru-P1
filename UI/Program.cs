using Models;
using CustomException;
using Microsoft.Data.SqlClient;
using DataAccess;
 
 
 UserRepository test = new UserRepository();
      List<User> user = test.GetAllUser();
        foreach (User item in user)
     {
         Console.WriteLine(item.userName);
     }