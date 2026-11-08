using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Repositories.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<T> Repository<T>() where T : BaseEntity;

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}