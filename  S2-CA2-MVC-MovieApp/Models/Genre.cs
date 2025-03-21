using System.ComponentModel.DataAnnotations;

namespace S2_CA2_MVC_MovieApp.Models;

public class Genre
{   
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public override string ToString() {
        return $"Id: {Id}, Name: {Name}";
    }
}
