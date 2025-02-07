//namespace Cinema.Models.Reports
//{

//    public class MongoDbMark
//    {
//        public int Score { get; set; }
//        public DateTime DateAwarded { get; set; }
//        public string TeacherName { get; set; }

//        public static MongoDbMark FromMark(Hall mark)
//        {
//            return new MongoDbMark
//            {
//                Score = mark.Score,
//                DateAwarded = mark.DateAwarded,
//                TeacherName = $"{mark.Teacher.FirstName} {mark.Teacher.LastName}"
//            };
//        }
//    }
//}