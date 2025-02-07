//using MongoDB.Bson;

//namespace Cinema.Models.Reports
//{
//    public class MongoDbReport
//    {
//        public ObjectId Id { get; set; }

//        public DateTime GeneratedDate { get; set; }

//        public List<MongoDbActor> Actors { get; set; }

//        public static MongoDbReport FromReport(Screening report)
//        {
//            return new MongoDbReport
//            {
//                GeneratedDate = report.DateTime,
//                Actors = report.Actors.Select(MongoDbActor.FromActor).ToList()
//            };
//        }
//    }
//}
