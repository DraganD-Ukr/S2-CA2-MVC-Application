namespace S2_CA2_MVC_MovieApp.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public int GenreId { get; set; } 
    public Genre Genre { get; set; } = null!;
    public String TrailerUrl { get; set; } = string.Empty;
    public String ImageUrl { get; set; } = string.Empty;
    public List<Review> Reviews { get; set; } = new();

    public override string ToString() {
        return $"Id: {Id}, Title: {Title}, Description: {Description}, ReleaseDate: {ReleaseDate}, GenreId: {GenreId}";
    }
}
