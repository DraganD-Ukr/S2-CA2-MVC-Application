using S2_CA2_MVC_MovieApp.Models;

namespace S2_CA2_MVC_MovieApp.Dto;

public class ToWatchMovie {
    
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public int GenreId { get; set; } 
    public Genre Genre { get; set; } = null!;
    public String TrailerUrl { get; set; } = string.Empty;
    public String ImageUrl { get; set; } = string.Empty;
    
}