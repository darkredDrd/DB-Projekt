namespace Cinema.Models { 

public class Hall
{
    public int Id { get; set; }

    public string Name { get; set; }  

    public int Seats { get; set; }

    public Building Building { get; set; }
 
}
}