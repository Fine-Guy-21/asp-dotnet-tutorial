using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace World_of_Soccer.Models
{
    public class SoccerContext : IdentityDbContext<AppUser>
    {
        public SoccerContext(DbContextOptions<SoccerContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<ImageGallery> imageGalleries { get; set; }

    }
}
