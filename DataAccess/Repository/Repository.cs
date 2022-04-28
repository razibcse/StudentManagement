using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context=context;
            this.dbSet=_context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById<Y>(Y id)
        {
           return dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRanges(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

    }
}
