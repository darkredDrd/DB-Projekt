namespace University.Models.Reports;

public class MongoDbMark
{
    public int Score { get; set; }
    public DateTime DateAwarded { get; set; }
    public string TeacherName { get; set; }

    public static MongoDbMark FromMark(Mark mark)
    {
        return new MongoDbMark
        {
            Score = mark.Score,
            DateAwarded = mark.DateAwarded,
            TeacherName = $"{mark.Teacher.FirstName} {mark.Teacher.LastName}"
        };
    }
}