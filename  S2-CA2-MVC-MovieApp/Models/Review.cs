using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace S2_CA2_MVC_MovieApp.Models;


public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;

    [Range(1, 10)]
    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;
}
