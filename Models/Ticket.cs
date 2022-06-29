namespace Tickets;

public class Tickets{

  private string ID{get; set;}
  private string Author{get; set;}
  private string resolver{get; set;}
  private string Description{get; set;}
  private string Status{get; set;}
  private string Amount{get; set;}


public Tickets(string ID, string Autor, string resolver, string Description, string status, string Amount){
    this.ID = ID;
    this.Author = Autor;
    this.resolver = resolver;
    this.Description = Description;
    this.Status = status;
    this.Amount = Amount;
}


public void getID(){
    Console.WriteLine("This the ID of the users" + this.Author);
    Console.WriteLine("I wanted to know if the ID is acceptable");
}
}

