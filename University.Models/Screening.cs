
namespace Cinema.Models
{
    public class Screening
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public Movie Movie { get; set; }

        public Hall Hall { get; set; }

        public Revenue Revenue { get; set; }


    }
}
