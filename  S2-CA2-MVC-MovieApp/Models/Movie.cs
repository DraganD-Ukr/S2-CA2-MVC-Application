namespace S2_CA2_MVC_MovieApp.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public int GenreId { get; set; } 
    public Genre Genre { get; set; } = null!;
    public List<Review> Reviews { get; set; } = new();
}
