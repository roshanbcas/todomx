namespace ToDoList.Repositories
{
    public abstract class BaseRepository<T>
    {
        private readonly IRepository<T> _repository;

        protected BaseRepository(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T Create(T entity)
        {
            return _repository.Create(entity);
        }

        public virtual T Update(int id, T entity)
        {
            return _repository.Update(id, entity);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
