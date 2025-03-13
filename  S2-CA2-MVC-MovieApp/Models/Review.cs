using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace S2_CA2_MVC_MovieApp.Models;


public class Review
{
    public int Id { get; set; }

    // Foreign key to Movie
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    // Foreign key to User
    public string UserId { get; set; } = string.Empty; // This is the ID of the user who wrote the review
    public User User { get; set; } = null!;  // Navigation property to User

    public string ReviewerName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;

    [Range(1, 10)]  // Ensure rating is between 1 and 10
    public int Rating { get; set; } 

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
