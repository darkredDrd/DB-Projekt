
namespace University.Models
{
    public class Screening
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Movie Movie { get; set; }

        public Hall Hall { get; set; }


    }
}
