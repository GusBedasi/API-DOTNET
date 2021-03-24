using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entites;

namespace Manager.Infrastructure.Interfaces {
    public interface IBaseRepository<T> where T : Base {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Delete(int obj);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
    }
}
