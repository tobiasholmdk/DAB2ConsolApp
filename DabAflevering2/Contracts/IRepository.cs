using System.Collections.Generic;
using System.Threading.Tasks;

namespace DabAflevering2.Contracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}