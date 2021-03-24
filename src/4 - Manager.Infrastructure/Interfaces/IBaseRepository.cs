using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entites;

namespace Manager.Infrastructure.Interfaces {
  public interface IBaseRepository<T> where T : Base {
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task<T> Delete(T obj);
    Task<T> Get(long id);
    Task<List<T>> GetAll();
  }

}
