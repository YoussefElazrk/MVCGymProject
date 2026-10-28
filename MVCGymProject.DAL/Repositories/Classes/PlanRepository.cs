using Microsoft.EntityFrameworkCore;
using MVCGymProject.DAL.Data;
using MVCGymProject.DAL.Models;
using MVCGymProject.DAL.Repositories.Interfaces;

namespace MVCGymProject.DAL.Repositories.Classes;

public class PlanRepository : IPlanRepository
{
    private readonly GymDbContext _dbContext;

    public PlanRepository(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Plan>> GetAllPlansAsync(bool trackChanges = false, CancellationToken ct = default)
    {
        return await GetPlansQuery(trackChanges).ToListAsync(ct);
    }

    public async Task<Plan?> GetPlanByIdAsync(int id, bool trackChanges = false, CancellationToken ct = default)
    {
        return await GetPlansQuery(trackChanges).FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<int> AddAsync(Plan plan, CancellationToken ct = default)
    {
        await _dbContext.Plans.AddAsync(plan, ct);
        return await _dbContext.SaveChangesAsync(ct);
    }

    public async Task<int> UpdateAsync(Plan plan, CancellationToken ct = default)
    {
        _dbContext.Plans.Update(plan);
        return await _dbContext.SaveChangesAsync(ct);
    }

    public async Task<int> DeleteAsync(Plan plan, CancellationToken ct = default)
    {
        _dbContext.Plans.Remove(plan);
        return await _dbContext.SaveChangesAsync(ct);
    }

    private IQueryable<Plan> GetPlansQuery(bool trackChanges)
    {
        IQueryable<Plan> query = _dbContext.Plans.IgnoreQueryFilters();
        return trackChanges ? query : query.AsNoTracking();
    }
}