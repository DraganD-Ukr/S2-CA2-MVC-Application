using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace S2_CA2_MVC_MovieApp.Models;

public class ToWatchList {
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string UserId { get; set; } = string.Empty;
    
    public List<Movie> Movies { get; set; } = new();
    
    public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
}