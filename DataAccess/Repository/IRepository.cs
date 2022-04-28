namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveRanges(IEnumerable<T> entities);
        T GetById<Y>(Y id);
        IEnumerable<T> GetAll();
    }
}
