using MediatR;

using Cinema.Models;

namespace Cinema.Application.Movies;

public class UpdateMovieCommand : IRequest
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Genre { get; set; }

    public int DurationMinutes { get; set; }

    public Movie ToMovie()
    {
        var movie = new Movie
        {
            Id = this.Id,
            Title = this.Title,
            Genre = this.Genre,
            DurationMinutes = this.DurationMinutes
        };

        return movie;
    }
}