using MongoDB.Bson;

namespace University.Models.Reports
{
    public class MongoDbReport
    {
        public ObjectId Id { get; set; }

        public DateTime GeneratedDate { get; set; }

        public List<MongoDbStudent> Students { get; set; }

        public static MongoDbReport FromReport(Report report)
        {
            return new MongoDbReport
            {
                GeneratedDate = report.GeneratedDate,
                Students = report.Students.Select(MongoDbStudent.FromStudent).ToList()
            };
        }

    }
}
