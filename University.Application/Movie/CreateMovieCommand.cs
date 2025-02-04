using MediatR;

using Cinema.Models;

namespace Cinema.Application.Movies;

public class CreateMovieCommand : IRequest
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int DurationMinutes { get; set; }

    public Movie ToMovie()
    {
        var movie = new Movie
        {
            Title = this.Title,
            Genre = this.Genre,
            DurationMinutes = this.DurationMinutes
        };

        return movie;
    }
}