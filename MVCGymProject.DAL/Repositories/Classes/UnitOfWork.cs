using MVCGymProject.DAL.Data;
using MVCGymProject.DAL.Models;
using MVCGymProject.DAL.Repositories.Interfaces;

namespace MVCGymProject.DAL.Repositories.Classes;

public class UnitOfWork : IUnitOfWork
{
    private readonly GymDbContext _dbContext;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        var type = typeof(T);

        if (!_repositories.TryGetValue(type, out var repository))
        {
            repository = new GenericRepository<T>(_dbContext);
            _repositories[type] = repository;
        }

        return (IGenericRepository<T>)repository;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return _dbContext.SaveChangesAsync(ct);
    }
}