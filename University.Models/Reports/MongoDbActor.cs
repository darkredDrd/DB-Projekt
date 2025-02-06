namespace Cinema.Models.Reports
{

    public class MongoDbActor
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<MongoDbCourse> Courses { get; set; }

        public static MongoDbActor FromActor(Actor actor)
        {

            var mongoDbActor = new MongoDbActor
            {
                FullName = $"{actor.FirstName} {actor.LastName}",
                BirthDate = actor.BirthDate
            };

            var courseGroups = actor.Marks.GroupBy(mark => mark.Course);//Marks gibt es nicht mehr was dann 
            mongoDbActor.Courses = courseGroups.Select(courseGroup => new MongoDbMovie
            {
                Topic = courseGroup.Key.Topic,
                TotalScore = courseGroup.Sum(mark => mark.Score),
                Movies = courseGroup.Select(MongoDbMark.FromMark).ToList()
            }).ToList();

            return mongoDbActor;
        }
    }
}