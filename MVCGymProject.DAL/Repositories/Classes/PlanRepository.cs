using Microsoft.EntityFrameworkCore;
using MVCGymProject.DAL.Repositories.Interfaces;
using MVCGymProject.Data;
using MVCGymProject.Models;

namespace MVCGymProject.DAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext _dbContext;
        public PlanRepository()
        {
            _dbContext = new GymDbContext();
        }

        public async Task<IEnumerable<Plan>> GetAllPlansAsync(bool trackChanges = false, CancellationToken ct = default)
        {
            var plans = trackChanges ? _dbContext.Plans.AsTracking().ToListAsync(ct) : _dbContext.Plans.AsNoTracking().ToListAsync(ct);
            return await plans;
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
}
