using Microsoft.EntityFrameworkCore;
using MVCGymProject.DAL.Models;
using System.Reflection;

namespace MVCGymProject.Data;

public class GymDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=GymDb;Trusted_Connection=True;trustservercertificate=true");
    }

    public DbSet<Plan> Plans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
}
