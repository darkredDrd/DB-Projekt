﻿using System.ComponentModel.DataAnnotations;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Movies;

public class MovieListViewModel
{
    public int Id { get; set; }

    [Display(Name = "Title")]
    public string Title { get; set; }

    [Display(Name = "Genre")]
    public string Genre { get; set; }

    [Display(Name = "Duration (minutes)")]
    public int DurationMinutes { get; set; }

    public static MovieListViewModel FromMovie(Movie movie)
    {
        var movieListViewModel = new MovieListViewModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            DurationMinutes = movie.DurationMinutes
        };

        return movieListViewModel;
    }
}