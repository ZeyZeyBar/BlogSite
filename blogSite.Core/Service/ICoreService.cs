using blogSite.Core.Entity;
using System.Linq.Expressions;

namespace blogSite.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        bool Add(T entity);
        bool Delete(int id);
        bool Update(T entity);
        T GetById(int id);
        T GetRecord(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        int Save();
    }
}
