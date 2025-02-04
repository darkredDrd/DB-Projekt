namespace Cinema.Models
{
    public class Revenue
    {
        public int Id { get; set; }

        public Screening Screening { get; set; }

        public float TotalRevenue { get; set; }
    }
}
