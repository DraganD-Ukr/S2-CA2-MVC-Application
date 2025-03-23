using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S2_CA2_MVC_MovieApp.Data;
using S2_CA2_MVC_MovieApp.Dto;
using S2_CA2_MVC_MovieApp.Models;

using S2_CA2_MVC_MovieApp.ViewModel;

namespace S2_CA2_MVC_MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<MovieController> _logger;
        private readonly SignInManager<User> _signInManager;

        public MovieController(ILogger<MovieController> logger, ApplicationDbContext dbContext, SignInManager<User> signInManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchTerm)
        {
            List<Movie> movies;

            if (string.IsNullOrEmpty(searchTerm)) {
                movies = _dbContext.Movies
                    .Include(m => m.Genre)
                    .Include(m => m.Reviews)
                    .OrderByDescending(m => m.ReleaseDate)
                    .Take(10)
                    .ToList();
                    
                    

                _logger.LogDebug("Returning first 10 movies from database.");
            }
            else
            {
                movies = _dbContext.Movies
                    .Include(m => m.Genre) // Ensure Genre is included
                    .Include(m => m.Reviews) // Ensure Reviews are included
                    .Where(m => m.Title.ToLower().Contains(searchTerm.ToLower()) )
                    .OrderBy(m => m.Title)
                    .ToList();

                _logger.LogInformation($"Search term: {searchTerm}, Found movies: {string.Join(", ", movies.Select(m => m.ToString()))}");
            }
            
            var searchViewModel = new SearchViewModel(movies, searchTerm);
            
            searchViewModel.Movies = movies;
            
            return View("Movie", searchViewModel);
        }

        public IActionResult Details(int id) {
            Movie? movie = _dbContext.Movies
                .Include(m => m.Genre)
                .Include(m => m.Reviews)
                .ThenInclude(r => r.User)
                .FirstOrDefault(m => m.Id == id);
                
            if (movie == null) {
                return NotFound();
            } 
            
            _logger.LogInformation(movie.ToString());

            return View("MovieDetails", movie);
        }


        [HttpPost]
        public IActionResult AddToWatchMovie(int id) {
            
            if (!_signInManager.IsSignedIn(User)) {
                return RedirectToAction("Search", "Movie");
            }
            
            String userId = _signInManager.UserManager.GetUserId(User);
            
            //Get users ToWatchList            
            ToWatchList toWatchList = _dbContext.ToWatchLists
                .Include(twl => twl.Movies)
                .FirstOrDefault(twl => twl.UserId == userId);
            
            
            if (toWatchList == null) {
                toWatchList = new ToWatchList
                {
                    UserId = userId,
                    Movies = new List<Movie>()
                };
            }
            
            
            Movie movie = _dbContext.Movies.Find(id);
            
            if (movie == null) {
                return NotFound();
            }
            
            toWatchList.Movies.Add(movie);
            
            _dbContext.ToWatchLists.Update(toWatchList);
            
            _dbContext.SaveChanges();
            
            return View("MoviesToWatch", toWatchList);
                
        }

        public async Task<IActionResult> GetToWatchMovies() {
    
            if (!_signInManager.IsSignedIn(User)) {
                return RedirectToAction("Search", "Movie");
            }

            string userId = _signInManager.UserManager.GetUserId(User);
    
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Search", "Movie");
            }

            var toWatchList = await _dbContext.ToWatchLists
                .Where(twl => twl.UserId == userId)
                .Include(twl => twl.Movies)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (toWatchList == null || !toWatchList.Movies.Any())
            {
                return View(new ToWatchList()); // Return an empty list to avoid null reference errors
            }

            return View("MoviesToWatch", toWatchList);
        }
        
        
    }
}