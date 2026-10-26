using Microsoft.EntityFrameworkCore;
using MVCGymProject.DAL.Models;
using System.Reflection;

namespace MVCGymProject.Data;

public class GymDbContext : DbContext
{
    public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
    {
    }

    public DbSet<Plan> Plans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Plan>().HasQueryFilter(p => p.IsActive);
    }
}
