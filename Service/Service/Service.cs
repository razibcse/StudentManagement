using DataAccess.Repository;

namespace Service.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById<Y>(Y id)
        {
            return _repository.GetById(id);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveRanges(IEnumerable<T> entities)
        {
            _repository.RemoveRanges(entities);
        }
    }
}
