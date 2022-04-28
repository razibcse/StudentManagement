namespace Service.Service
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveRanges(IEnumerable<T> entities);
        T GetById<Y>(Y id);
        IEnumerable<T> GetAll();
    }
}
