using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace UserGroup.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}