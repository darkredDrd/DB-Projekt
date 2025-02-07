namespace Cinema.Models.Reports
{
    public class MongoDbActor
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<MongoDbMovie> Movies { get; set; }

        public static MongoDbActor FromActor(Actor actor)
        {
            var mongoDbActor = new MongoDbActor
            {
                FullName = $"{actor.FirstName} {actor.LastName}",
                BirthDate = actor.BirthDate,
                Movies = actor.Movies.Select(MongoDbMovie.FromMovie).ToList()
            };

            return mongoDbActor;
        }
    }
}
