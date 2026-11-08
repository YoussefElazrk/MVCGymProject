using Microsoft.EntityFrameworkCore;
using MVCGymProject.DAL.Data;
using MVCGymProject.DAL.Models;
using MVCGymProject.DAL.Repositories.Interfaces;

namespace MVCGymProject.DAL.Repositories.Classes;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly GymDbContext _dbContext;

    public GenericRepository(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false, CancellationToken ct = default)
    {
        return await GetQuery(trackChanges).ToListAsync(ct);
    }

    public async Task<T?> GetByIdAsync(int id, bool trackChanges = false, CancellationToken ct = default)
    {
        return await GetQuery(trackChanges).FirstOrDefaultAsync(e => e.Id == id, ct);
    }

    public async Task AddAsync(T entity, CancellationToken ct = default)
    {
        await _dbContext.Set<T>().AddAsync(entity, ct);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void Remove(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    protected virtual IQueryable<T> GetQuery(bool trackChanges)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        return trackChanges ? query : query.AsNoTracking();
    }
}