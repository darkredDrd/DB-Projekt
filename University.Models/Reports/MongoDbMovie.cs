namespace Cinema.Models.Reports
{
    public class MongoDbMovie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int DurationMinutes { get; set; }

        public static MongoDbMovie FromMovie(Movie movie)
        {
            return new MongoDbMovie
            {
                Title = movie.Title,
                Genre = movie.Genre,
                DurationMinutes = movie.DurationMinutes
            };
        }
    }
}
