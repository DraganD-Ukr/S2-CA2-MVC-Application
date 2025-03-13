using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using S2_CA2_MVC_MovieApp.Data;
using S2_CA2_MVC_MovieApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add DbContext for Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add Razor Pages and MVC
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Add database developer page exception filter
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();



// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Ensure database is created without migrations
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated(); // This will create the database if not already created
        
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
    
        // Create the database and apply the schema
        dbContext.Database.EnsureCreated(); // This ensures the tables are created

        await dbContext.SeedUsersAsync(services); // Make sure SeedUsersAsync is properly implemented
    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();  // Add this line for authentication middleware
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
    .WithStaticAssets();

app.Run();
