using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProvinceCity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
// builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(connectionString));

var host = builder.Configuration["DBHOST"] ?? "localhost";
var port = builder.Configuration["DBPORT"] ?? "1433";
var password = builder.Configuration["DBPASSWORD"] ?? "SqlPassword!";
var db = builder.Configuration["DBNAME"] ?? "ProvCityDatabaseDB";

string connectionString = $"Data Source={host},{port};Database={db};Persist Security Info=True;User ID=sa;Password={password};TrustServerCertificate=True;";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

    
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();    
    context.Database.Migrate();
}

app.Run();
