using Manager.Infrastructure.Interfaces;
using Manager.Infrastructure.Context;
using Manager.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;


namespace Manager.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base{
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Creatre(T obj){
            _context.Add(obj);
            await _context.SaveChangeAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj){
            _context.Entryy(obj).State = EntityState.Modified;
            await _context.SaveChangeAsync();

            return obj;
        }

        public virtual async Task Delete(int id) {
            var obj = await Get(id);
         
            if(obj != null) {
              _context.Remove(obj);
              await _context.SaveChangeAsync();
            }
        }

        public virtual async Task<T> Get(int id) {
            var obj = await _context.Set<T>()
                                    .AsNotTracking()
                                    .Wherew(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async List<Task<T>> GetAll() {
            return await _context.Set<T>
                                 .AsNotTracking();
                                 .ToListAsync();
        }
    }
}