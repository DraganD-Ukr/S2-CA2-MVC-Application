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

        public DbSet<Movie?> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ToWatchList> ToWatchLists { get; set; }

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
                new Movie { Id = 1, Title = "John Wick", Description = "An ex-hitman comes out of retirement.", ReleaseDate = new DateTime(2014, 10, 24, 0, 0, 0, DateTimeKind.Utc), GenreId = 1, ImageUrl = "https://static.wikia.nocookie.net/john-wick8561/images/d/d5/JW1_final_poster_release.jpg/revision/latest?cb=20231215021818", TrailerUrl = "https://www.youtube.com/watch?v=C0BMx-qxsP4&ab_channel=RottenTomatoesTrailers"},
                new Movie { Id = 2, Title = "Superbad", Description = "Two co-dependent high school guys try to score alcohol.", ReleaseDate = new DateTime(2007, 8, 17, 0, 0, 0, DateTimeKind.Utc), GenreId = 2, ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fencrypted-tbn2.gstatic.com%2Fimages%3Fq%3Dtbn%3AANd9GcTJmGobpUVCddF0JO9XmZjQ6xsHGC53RXulyGpAxr0nK7nuuaK4&psig=AOvVaw2j0QRXN00R0T8NZA0XhikV&ust=1742429316482000&source=images&cd=vfe&opi=89978449&ved=0CBAQjRxqFwoTCODg1pbtlIwDFQAAAAAdAAAAABAZ",  TrailerUrl = "https://www.youtube.com/watch?v=LvKvus3vCEY&ab_channel=SonyPicturesEntertainment"},
                new Movie { Id = 3, Title = "The Shawshank Redemption", Description = "A banker is sentenced to life in Shawshank prison.", ReleaseDate = new DateTime(1994, 9, 23, 0, 0, 0, DateTimeKind.Utc), GenreId = 3 , ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSf1DK32xKMQzqSl8wnY1BLVu_gdwsRYzVSNM6A03r6c-fEwrif8raKzkFRuerw1KHdDICvOw", TrailerUrl = "https://www.youtube.com/watch?v=PLl99DlL6b4&ab_channel=WarnerBros.Entertainment"},
                new Movie { Id = 4, Title = "Interstellar", Description = "A group of explorers travels through a wormhole in space.", ReleaseDate = new DateTime(2014, 11, 7, 0, 0, 0, DateTimeKind.Utc), GenreId = 4, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSngBJ0B7UDrLUkDlp6DCQLsEYuWR-DiHwbnxFFCniB3HiP3f3NZmR1-lKSC34ge6YXu4LX", TrailerUrl = "https://www.youtube.com/watch?v=zSWdZVtXT7E&ab_channel=WarnerBros.UK%26Ireland"},
                new Movie { Id = 5, Title = "The Conjuring", Description = "Paranormal investigators work to help a family terrorized by a dark presence.", ReleaseDate = new DateTime(2013, 7, 19, 0, 0, 0, DateTimeKind.Utc), GenreId = 5, ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQeqClg9WkzGhd4gNWXa-gJGeZS_2HkNNclIzPhy66CKBnamMAY0TcbQZmWTuD4otPUjmtlFA", TrailerUrl = "https://www.youtube.com/watch?v=k10ETZ41q5o&ab_channel=WarnerBros."},
                new Movie { Id = 6, Title = "Titanic", Description = "A young couple falls in love aboard the doomed ship.", ReleaseDate = new DateTime(1997, 12, 19, 0, 0, 0, DateTimeKind.Utc), GenreId = 6, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRlcQXin_CNozAFkv_SSihe5eZ_lvDD5nBqCmQT3xPf6KLlqHloIo5cBRGqwuy8pjuIiZrqoA", TrailerUrl = "https://www.youtube.com/watch?v=h8zXnJTHky8&ab_channel=20thCenturyStudiosIE"},
                new Movie { Id = 7, Title = "The Lord of the Rings: The Fellowship of the Ring", Description = "A hobbit embarks on a journey to destroy a powerful ring.", ReleaseDate = new DateTime(2001, 12, 19, 0, 0, 0, DateTimeKind.Utc), GenreId = 7, ImageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQo30od32lIWQa6zwGGRoYSCd4k80Qbmk8GK_JuvOARWapL5DaYxSIVH9D8qJCrdBxZvqx54A", TrailerUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips"},
                new Movie { Id = 8, Title = "Inception", Description = "A thief who enters dreams to steal secrets faces his biggest challenge.", ReleaseDate = new DateTime(2010, 7, 16, 0, 0, 0, DateTimeKind.Utc), GenreId = 4, ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRRyuWmayVBvqjd1MxTKpRgauq2cCtUzb7Q9QvaFTkAuxAU_EYMoCE3wBuJeftxIzf0grreIw", TrailerUrl = "https://www.youtube.com/watch?v=YoHD9XEInc0&ab_channel=RottenTomatoesClassicTrailers"},
                new Movie { Id = 9, Title = "The Dark Knight", Description = "Batman battles the Joker to save Gotham City.", ReleaseDate = new DateTime(2008, 7, 18, 0, 0, 0, DateTimeKind.Utc), GenreId = 8, ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTfE_qrYMBZ_JB8om-34WGaZARhpX26yWRttqIDvn4_7l--UzX8mxKcPrc59IcvTpEA_G8gPA", TrailerUrl = "https://www.youtube.com/watch?v=EXeTwQWrcwY&ab_channel=RottenTomatoesClassicTrailers"},
                new Movie { Id = 10, Title = "Finding Nemo", Description = "A clownfish searches for his lost son.", ReleaseDate = new DateTime(2003, 5, 30, 0, 0, 0, DateTimeKind.Utc), GenreId = 9, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_L85MrBiZe4VhDdeGczFkEryBaUSm9OxNBW79a2ABLzpLCTdH5qasRt11inzqTTUXk2-G", TrailerUrl = "https://www.youtube.com/watch?v=SPHfeNgogVs&ab_channel=Pixar"}
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
            await SeedUserAsync(userManager, "user1@example.com", "user1@example.com", "User");
            await SeedUserAsync(userManager, "user2@example.com", "user2@example.com", "User");
            await SeedUserAsync(userManager, "user3@example.com", "user3@example.com", "User");
            await SeedUserAsync(userManager, "user4@example.com", "user4@example.com", "User");
            await SeedUserAsync(userManager, "user5@example.com", "user5@example.com", "User");
        }

        public async Task SeedReviewsAsync(ApplicationDbContext context, UserManager<User> userManager)
        {
            if (!context.Reviews.Any())
            {
                // Get User IDs dynamically by username
                var user1 = await userManager.FindByNameAsync("user1@example.com");
                var user2 = await userManager.FindByNameAsync("user2@example.com");
                var user3 = await userManager.FindByNameAsync("user3@example.com");

                var reviews = new List<Review>
                {
                    new Review {  MovieId = 1, UserId = user1?.Id, Rating = 9, Comment = "Amazing action sequences!" },
                    new Review {  MovieId = 2, UserId = user1?.Id, Rating = 8, Comment = "Hilarious and entertaining." },
                    new Review {  MovieId = 3, UserId = user1?.Id, Rating = 10, Comment = "One of the best movies ever!" },
                    new Review {  MovieId = 4, UserId = user2?.Id, Rating = 9, Comment = "Mind-blowing visuals and concept." },
                    new Review {  MovieId = 5, UserId = user2?.Id, Rating = 7, Comment = "Scary and intense." },
                    new Review {  MovieId = 6, UserId = user3?.Id, Rating = 10, Comment = "Heartbreaking and beautiful." },
                    new Review {  MovieId = 7, UserId = user3?.Id, Rating = 9, Comment = "Epic fantasy adventure!" },
                    new Review {  MovieId = 6, UserId = user3?.Id, Rating = 10, Comment = "Beautiful!!." },
                    new Review {  MovieId = 7, UserId = user3?.Id, Rating = 9, Comment = "Enjoyed it!" }
                };

                await context.Reviews.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }
        }

        public async Task SeedToWatchListAsync(ApplicationDbContext context, UserManager<User> userManager) {
            
            
            if (!context.ToWatchLists.Any()) 
            {
                var user1 = await userManager.FindByNameAsync("user1@example.com");
                var user2 = await userManager.FindByNameAsync("user2@example.com");

                if (user1 == null || user2 == null)
                    throw new Exception("One or both users not found.");

                // Get the first 10 movies
                var movies = await context.Movies.Include(m => m.Genre).Take(10).ToListAsync();

                if (movies.Count < 10)
                    throw new Exception("Not enough movies in the database.");

                // Assign first 5 movies to user1, last 5 to user2
                var toWatchLists = new List<ToWatchList>
                {
                    new ToWatchList 
                    { 
                        UserId = user1.Id, 
                        Movies = movies.Take(5).ToList(), // First 5 movies
                        LastUpdatedAt = DateTime.UtcNow
                    },
                    new ToWatchList 
                    { 
                        UserId = user2.Id, 
                        Movies = movies.Skip(5).Take(5).ToList(), // Last 5 movies
                        LastUpdatedAt = DateTime.UtcNow
                    }
                };

                // Add to the database
                await context.ToWatchLists.AddRangeAsync(toWatchLists);
                await context.SaveChangesAsync();
            }
            
            
        }


    }
}