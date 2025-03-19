using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S2_CA2_MVC_MovieApp.Data;
using S2_CA2_MVC_MovieApp.Models;

using S2_CA2_MVC_MovieApp.ViewModel;

namespace S2_CA2_MVC_MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchTerm)
        {
            List<Movie> movies;

            if (string.IsNullOrEmpty(searchTerm))
            {
                movies = _dbContext.Movies
                    .Include(m => m.Genre)
                    .Include(m => m.Reviews)
                    .OrderBy(m => m.Title)
                    .Take(10)
                    .ToList();

                _logger.LogDebug("Returning first 10 movies from database.");
            }
            else
            {
                movies = _dbContext.Movies
                    .Include(m => m.Genre) // Ensure Genre is included
                    .Include(m => m.Reviews) // Ensure Reviews are included
                    .Where(m => m.Title.ToLower().Contains(searchTerm.ToLower()) || 
                                m.Description.ToLower().Contains(searchTerm.ToLower()))
                    .OrderBy(m => m.Title)
                    .ToList();

                _logger.LogInformation($"Search term: {searchTerm}, Found movies: {string.Join(", ", movies.Select(m => m.ToString()))}");
            }
            
            var searchViewModel = new SearchViewModel(movies, searchTerm);
            
            searchViewModel.Movies = movies;
            
            return View("Movie", searchViewModel);
        }
    }
}