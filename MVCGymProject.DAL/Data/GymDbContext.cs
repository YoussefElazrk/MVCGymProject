using Microsoft.EntityFrameworkCore;
using MVCGymProject.DAL.Models;
using System.Reflection;

namespace MVCGymProject.DAL.Data;

public class GymDbContext : DbContext
{

    public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members => Set<Member>();
    public DbSet<Trainer> Trainers => Set<Trainer>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Session> Sessions => Set<Session>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        SetUpdatedAt();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetUpdatedAt();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetUpdatedAt()
    {
        var modifiedEntries = ChangeTracker.Entries<BaseEntity>()
                                           .Where(e => e.State == EntityState.Modified);

        foreach (var entry in modifiedEntries)
        {
            entry.Entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}


