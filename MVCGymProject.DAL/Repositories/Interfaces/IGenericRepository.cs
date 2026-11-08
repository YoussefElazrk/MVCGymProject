using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false, CancellationToken ct = default);
    Task<T?> GetByIdAsync(int id, bool trackChanges = false, CancellationToken ct = default);
    Task AddAsync(T entity, CancellationToken ct = default);
    void Update(T entity);
    void Remove(T entity);
}
