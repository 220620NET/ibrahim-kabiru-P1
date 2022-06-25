namespace model;

public class user {

private string userID{get; set;}

private string userName{get; set;}
private string Password{get; set;}
private string role{get; set;}


public void user(string userID, string userName, string Password, string role){
    this.userID = userID;
    this.userName = userName;
    this.Password = Password;
    this.role = role;
}

}

 




