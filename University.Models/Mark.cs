namespace University.Models;

public class Mark
{
    public int Id { get; set; }

    public int Score { get; set; }

    public DateTime DateAwarded { get; set; }

    public Student Student { get; set; }
    public Teacher Teacher { get; set; }
    public Course Course { get; set; }
}