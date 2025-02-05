using MongoDB.Bson;

namespace Cinema.Models.Reports
{
    public class MongoDbReport
    {
        public ObjectId Id { get; set; }

        public DateTime GeneratedDate { get; set; }

        public List<MongoDbActor> Students { get; set; }

        public static MongoDbReport FromReport(Screening report)
        {
            return new MongoDbReport
            {
                GeneratedDate = report.GeneratedDate,
                Students = report.Students.Select(MongoDbActor.FromStudent).ToList()
            };
        }

    }
}
