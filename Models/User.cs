namespace Models;

public class User{

public int userID{get; set;}

public string userName{get; set;}
public string Password{get; set;}
public string role{get; set;}


public User(int userID, string userName, string Password, string role){
    this.userID = userID;
    this.userName = userName;
    this.Password = Password;
    this.role = role;
}

}

 




