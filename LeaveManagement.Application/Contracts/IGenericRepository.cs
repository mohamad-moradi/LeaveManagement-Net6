using LeaveManagement.Data;

namespace LeaveManagement.Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T?> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<bool> Exists(int id);
    }
}
