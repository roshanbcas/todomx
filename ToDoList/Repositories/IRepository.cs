namespace ToDoList.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Update(int id, T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
