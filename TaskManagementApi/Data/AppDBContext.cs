using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Entities;

namespace TaskManagementApi.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProjectTask> Tasks => Set<ProjectTask>();
    }
}
