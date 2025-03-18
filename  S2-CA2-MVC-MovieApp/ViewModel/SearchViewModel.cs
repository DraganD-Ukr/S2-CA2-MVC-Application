using S2_CA2_MVC_MovieApp.Models;

namespace S2_CA2_MVC_MovieApp.ViewModel;

public class SearchViewModel {
    public List<Movie> Movies { get; set; }
    public string SearchTerm { get; set; }
    
    public SearchViewModel(List<Movie> movies, string searchTerm) {
        Movies = movies;
        SearchTerm = searchTerm;
    }
}