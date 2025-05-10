using blogSite.Core.Entity;
using blogSite.Core.Service;
using blogSite.Model.Context;
using System.Linq.Expressions;

namespace blogSite.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly blogSiteContex _db;
        public BaseService(blogSiteContex db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _db.Set<T>().Remove(GetById(id));
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<T> GetAll()=>_db.Set<T>().ToList();

        public T GetById(int id)=>_db.Set<T>().Find(id);
        public T GetRecord(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().FirstOrDefault(predicate);
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public bool Update(T entity)
        {
            try
            {
                _db.Set<T>().Update(entity);
                return Save() > 0;

            }
            catch (Exception) { 
                return false;
            }
        }
    }
}
