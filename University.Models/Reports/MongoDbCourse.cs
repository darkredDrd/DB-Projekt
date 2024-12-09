namespace University.Models.Reports;

public class MongoDbCourse
{
    public string Topic { get; set; }
    public int TotalScore { get; set; }

    public List<MongoDbMark> Marks { get; set; }

    public static MongoDbCourse FromCourse(Student student, Course course)
    {
        return new MongoDbCourse
        {
            Topic = course.Topic,
            TotalScore = course.Marks.Sum(m => m.Score),
            Marks = student.Marks.Where(mark => course.Marks.Select(m => m.Id).Contains(mark.Id)).Select(MongoDbMark.FromMark).ToList()
        };
    }
}