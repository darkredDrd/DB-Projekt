namespace Cinema.Models.Reports
{

    public class MongoDbStudent
    {
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }

        public List<MongoDbCourse> Courses { get; set; }

        public static MongoDbStudent FromStudent(Revenue student)
        {

            var mongoDbStudent = new MongoDbStudent
            {
                FullName = $"{student.FirstName} {student.LastName}",
                Birthday = student.Birthday
            };

            var courseGroups = student.Marks.GroupBy(mark => mark.Course);
            mongoDbStudent.Courses = courseGroups.Select(courseGroup => new MongoDbCourse
            {
                Topic = courseGroup.Key.Topic,
                TotalScore = courseGroup.Sum(mark => mark.Score),
                Marks = courseGroup.Select(MongoDbMark.FromMark).ToList()
            }).ToList();

            return mongoDbStudent;
        }
    }
}