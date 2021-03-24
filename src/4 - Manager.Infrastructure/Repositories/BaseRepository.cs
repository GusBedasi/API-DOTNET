using Manager.Infrastructure.Interfaces;

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
    }
}