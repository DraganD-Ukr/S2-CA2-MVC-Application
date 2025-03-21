using Microsoft.AspNetCore.Identity;
using S2_CA2_MVC_MovieApp.Data;
using S2_CA2_MVC_MovieApp.Dto;
using S2_CA2_MVC_MovieApp.Models;

namespace S2_CA2_MVC_MovieApp.Controllers;
using Microsoft.AspNetCore.Mvc;


public class ReviewController : Controller {
    
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<MovieController> _logger;
    private readonly SignInManager<User> _signInManager;
    
    public ReviewController(ILogger<MovieController> logger, ApplicationDbContext dbContext, SignInManager<User> signInManager) {
        _logger = logger;
        _dbContext = dbContext;
        _signInManager = signInManager;
    }

    [HttpPost]
    public IActionResult AddReview(ReviewPostRequest review) {
        
        if (!ModelState.IsValid) {
            return RedirectToAction("Details", "Movie", new {id = review.MovieId});
        }

        if (!_signInManager.IsSignedIn(User)) {
            return RedirectToAction("Details", "Movie", new {id = review.MovieId});
        }
        
        
        Review newReview = new Review {
            
            MovieId = review.MovieId,
            Rating = review.Rating,
            Comment = review.Comment,
            UserId = _signInManager.UserManager.GetUserId(User),
        };
        
        _dbContext.Reviews.Add(newReview);
        _dbContext.SaveChanges();
        return RedirectToAction("Details", "Movie", new {id = review.MovieId});
    }
    
    
}