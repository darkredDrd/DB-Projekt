namespace Cinema.Models.Reports { 

public class MongoDbCourse
{
    public string Topic { get; set; }
    public int TotalScore { get; set; }

    public List<MongoDbMark> Marks { get; set; }
}
}