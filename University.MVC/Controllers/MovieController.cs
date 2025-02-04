using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cinema.Application.Movies;
using Cinema.MVC.ViewModels.Movies;

namespace Cinema.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMediator mediator;

        public MoviesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var getMoviesQuery = new GetMoviesQuery();
            var movies = await this.mediator.Send(getMoviesQuery);

            var movieListViewModels = movies.Select(MovieListViewModel.FromMovie).ToList();

            return View(movieListViewModels);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getMovieQuery = new GetMovieQuery { Id = id.Value };
            var movie = await this.mediator.Send(getMovieQuery);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDetailsViewModel = MovieDetailsViewModel.FromMovie(movie);

            return View(movieDetailsViewModel);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateViewModel movieCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createMovieCommand = movieCreateViewModel.ToCreateMovieCommand();
                await mediator.Send(createMovieCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(movieCreateViewModel);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getMovieQuery = new GetMovieQuery { Id = id.Value };
            var movie = await this.mediator.Send(getMovieQuery);

            var movieUpdateViewModel = MovieUpdateViewModel.FromMovie(movie);
            return View(movieUpdateViewModel);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieUpdateViewModel movieUpdateViewModel)
        {
            if (id != movieUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updateMovieCommand = movieUpdateViewModel.ToUpdateMovieCommand();
                await this.mediator.Send(updateMovieCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(movieUpdateViewModel);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getMovieQuery = new GetMovieQuery { Id = id.Value };
            var movie = await this.mediator.Send(getMovieQuery);
            if (movie == null)
            {
                return NotFound();
            }

            var movieDetailsViewModel = MovieDetailsViewModel.FromMovie(movie);

            return View(movieDetailsViewModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteMovieCommand = new DeleteMovieCommand { Id = id };
            await this.mediator.Send(deleteMovieCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}