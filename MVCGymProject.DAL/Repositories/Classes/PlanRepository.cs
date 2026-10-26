using Microsoft.EntityFrameworkCore;
using MVCGymProject.DAL.Models;
using MVCGymProject.DAL.Repositories.Interfaces;
using MVCGymProject.Data;

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
        var plans = trackChanges ? await _dbContext.Plans.IgnoreQueryFilters().AsTracking().ToListAsync(ct) : await _dbContext.Plans.IgnoreQueryFilters().AsNoTracking().ToListAsync(ct);
        return plans;
    }
    public async Task<Plan> GetPlanByIdAsync(int id, bool trackChanges = false, CancellationToken ct = default)
    {
        var plan = _dbContext.Plans.FindAsync(id, ct);
        return await plan;
    }
    public async Task<int> AddAsync(Plan plan, CancellationToken ct = default)
    {
        _dbContext.Plans.Add(plan);
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






}
