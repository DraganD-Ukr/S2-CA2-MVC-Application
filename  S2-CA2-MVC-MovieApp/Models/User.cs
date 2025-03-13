using Microsoft.AspNetCore.Identity;

namespace S2_CA2_MVC_MovieApp.Models;

public class User : IdentityUser {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
 
}