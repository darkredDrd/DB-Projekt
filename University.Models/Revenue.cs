namespace University.Models
{
    public class Revenue
    {
        public int Id { get; set; }

        public Screening Screening { get; set; }

        public float totalRevenue { get; set; }
    }
}
