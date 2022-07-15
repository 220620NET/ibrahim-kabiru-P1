namespace Models;

public class Tickets{

  private string ID{get; set;}
  private string Author{get; set;}
  private string resolver{get; set;}
  private string Description{get; set;}
  private string Status{get; set;}
  private decimal Amount{get; set;}


public Tickets(string ID, string Autor, string resolver, string Description, string status, decimal Amount){
    this.ID = ID;
    this.Author = Autor;
    this.resolver = resolver;
    this.Description = Description;
    this.Status = status;
    this.Amount = Amount;
}



}


