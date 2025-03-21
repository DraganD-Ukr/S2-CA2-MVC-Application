using System.ComponentModel.DataAnnotations;


namespace S2_CA2_MVC_MovieApp.Models;


public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int MovieId { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;

    [Range(1, 10)]
    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;
    
    public override string ToString() {
        return $"Id: {Id}, UserId: {UserId}, Rating: {Rating}, Comment: {Comment}";
    }   
}
