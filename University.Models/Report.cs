
using System.Runtime.InteropServices.JavaScript;

namespace University.Models
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime GeneratedDate { get; set; }

        public List<Student> Students { get; set; }
}
}
