using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using S2_CA2_MVC_MovieApp.Models;

namespace S2_CA2_MVC_MovieApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            

            // Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            // Seed Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Drama" },
                new Genre { Id = 4, Name = "Sci-Fi" },
                new Genre { Id = 5, Name = "Horror" },
                new Genre { Id = 6, Name = "Romance" },
                new Genre { Id = 7, Name = "Fantasy" },
                new Genre { Id = 8, Name = "Thriller" },
                new Genre { Id = 9, Name = "Animation" }
            );

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "John Wick", Description = "An ex-hitman comes out of retirement.", ReleaseDate = new DateTime(2014, 10, 24, 0, 0, 0, DateTimeKind.Utc), GenreId = 1 },
                new Movie { Id = 2, Title = "Superbad", Description = "Two co-dependent high school guys try to score alcohol.", ReleaseDate = new DateTime(2007, 8, 17, 0, 0, 0, DateTimeKind.Utc), GenreId = 2 },
                new Movie { Id = 3, Title = "The Shawshank Redemption", Description = "A banker is sentenced to life in Shawshank prison.", ReleaseDate = new DateTime(1994, 9, 23, 0, 0, 0, DateTimeKind.Utc), GenreId = 3 },
                new Movie { Id = 4, Title = "Interstellar", Description = "A group of explorers travels through a wormhole in space.", ReleaseDate = new DateTime(2014, 11, 7, 0, 0, 0, DateTimeKind.Utc), GenreId = 4 },
                new Movie { Id = 5, Title = "The Conjuring", Description = "Paranormal investigators work to help a family terrorized by a dark presence.", ReleaseDate = new DateTime(2013, 7, 19, 0, 0, 0, DateTimeKind.Utc), GenreId = 5 },
                new Movie { Id = 6, Title = "Titanic", Description = "A young couple falls in love aboard the doomed ship.", ReleaseDate = new DateTime(1997, 12, 19, 0, 0, 0, DateTimeKind.Utc), GenreId = 6 },
                new Movie { Id = 7, Title = "The Lord of the Rings: The Fellowship of the Ring", Description = "A hobbit embarks on a journey to destroy a powerful ring.", ReleaseDate = new DateTime(2001, 12, 19, 0, 0, 0, DateTimeKind.Utc), GenreId = 7 },
                new Movie { Id = 8, Title = "Inception", Description = "A thief who enters dreams to steal secrets faces his biggest challenge.", ReleaseDate = new DateTime(2010, 7, 16, 0, 0, 0, DateTimeKind.Utc), GenreId = 4 },
                new Movie { Id = 9, Title = "The Dark Knight", Description = "Batman battles the Joker to save Gotham City.", ReleaseDate = new DateTime(2008, 7, 18, 0, 0, 0, DateTimeKind.Utc), GenreId = 8 },
                new Movie { Id = 10, Title = "Finding Nemo", Description = "A clownfish searches for his lost son.", ReleaseDate = new DateTime(2003, 5, 30, 0, 0, 0, DateTimeKind.Utc), GenreId = 9 }
            );

            // Seed Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, MovieId = 1, Rating = 9, Comment = "Amazing action scenes!" },
                new Review { Id = 2, MovieId = 2, Rating = 8, Comment = "Super funny!" },
                new Review { Id = 3, MovieId = 3, Rating = 10, Comment = "One of the best movies ever." },
                new Review { Id = 4, MovieId = 4, Rating = 9, Comment = "Incredible visuals and storytelling." },
                new Review { Id = 5, MovieId = 5, Rating = 7, Comment = "Scary and well-directed!" },
                new Review { Id = 6, MovieId = 6, Rating = 10, Comment = "A beautiful and tragic love story." },
                new Review { Id = 7, MovieId = 7, Rating = 10, Comment = "An epic adventure!" },
                new Review { Id = 8, MovieId = 8, Rating = 9, Comment = "Mind-blowing and deep." },
                new Review { Id = 9, MovieId = 9, Rating = 10, Comment = "Best superhero movie ever!" },
                new Review { Id = 10, MovieId = 10, Rating = 8, Comment = "Great animation and story." }
            );
        }

        private async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName) == false)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        private async Task SeedUserAsync(UserManager<User> userManager, string username, string email, string role)
        {
            if (await userManager.FindByNameAsync(username) == null)
            {
                var user = new User
                {
                    UserName = username,
                    Email = email,
                    FirstName = role == "Admin" ? "Admin" : "Regular",
                    LastName = role == "Admin" ? "User" : "User"
                };
                var result = await userManager.CreateAsync(user, "Password123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        public async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoleAsync(roleManager, "Admin");
            await SeedRoleAsync(roleManager, "User");

            await SeedUserAsync(userManager, "admin@example.com", "admin@example.com", "Admin");
            await SeedUserAsync(userManager, "user@example.com", "user@example.com", "User");
        }
    }
}