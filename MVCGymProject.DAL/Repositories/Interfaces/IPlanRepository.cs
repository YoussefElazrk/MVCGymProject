using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Repositories.Interfaces;

public interface IPlanRepository
{
    // CRUD operations for Plan entity
    Task<IEnumerable<Plan>> GetAllPlansAsync(bool trackChanges = false, CancellationToken ct = default);
    Task<Plan?> GetPlanByIdAsync(int id, bool trackChanges = false, CancellationToken ct = default);
    Task<int> AddAsync(Plan plan, CancellationToken ct = default);
    Task<int> UpdateAsync(Plan plan, CancellationToken ct = default);
    Task<int> DeleteAsync(Plan plan, CancellationToken ct = default);
}