using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using World_of_Soccer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ConnString = builder.Configuration.GetConnectionString("MySQlConn");
 
builder.Services.AddDbContext<SoccerContext>(options =>
    {
         options.UseMySql(ConnString, ServerVersion.AutoDetect(ConnString));
    });

builder.Services.AddIdentity<AppUser,IdentityRole>().
    AddEntityFrameworkStores<SoccerContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
