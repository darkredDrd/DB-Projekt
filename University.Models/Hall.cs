﻿namespace Cinema.Models { 

public class Hall
{
    public int Id { get; set; }

    public string Name { get; set; }  

    public int Seats { get; set; }

    public Cinema Cinema { get; set; }
 
}
}