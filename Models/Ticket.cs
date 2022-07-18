namespace Models;

public class Tickets{

  public int ID{get; set;}
  public string Author{get; set;}
  public string resolver{get; set;}
  public string Description{get; set;}
  public string Status{get; set;}
  public decimal Amount{get; set;}
public Tickets(string Author, string resolver, string Description, string status, decimal Amount){
  this.Author = Author;
  this.resolver = resolver;
  this.Description = Description;
  this.Status = status;
  this.Amount = Amount;
}
public Tickets(){}

public Tickets(int ID, string Autor, string resolver, string Description, string status, decimal Amount){
    this.ID = ID;
    this.Author = Autor;
    this.resolver = resolver;
    this.Description = Description;
    this.Status = status;
    this.Amount = Amount;
}
public override string ToString(){
   return " ID: " + this.ID +
   ", Author: " + this.Author +
   ", resolver: " + this.resolver +
   ", Description: " + this.Description +
   ", Status: " + this.Status +
   ", Amount: " + this.Amount;
}


}


