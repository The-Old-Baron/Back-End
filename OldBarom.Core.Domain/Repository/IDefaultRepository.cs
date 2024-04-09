
namespace OldBarom.Core.Domain.Repository
{
    public interface IDefaultRepository<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(string guid);
    }
}
