﻿namespace Models;

public class User{

public int userID{get; set;}

public string userName{get; set;}
public string Password{get; set;}
public string role{get; set;}

public User(string userName, string Password, string role){
    this.userName = userName;
    this.Password = Password;
    this.role = role;
}
public User(){}
public User(int userID, string userName, string Password, string role){
    this.userID = userID;
    this.userName = userName;
    this.Password = Password;
    this.role = role;
}
   public override string ToString() {
        return "User ID: " + this.userID +
        ", Username: " + this.userName +
        ", Password: " + this.Password +
        ", Role: " + this.role;
    }
}

 




