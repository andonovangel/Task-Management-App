using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Entities;

namespace TaskManagementApi.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProjectTask> Tasks => Set<ProjectTask>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "Admin",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "User",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
