namespace ToDoList.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private readonly ToDoListDbContext _dbContext;
        public TaskRepository(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Create(Task entity)
        {
            _dbContext.Tasks.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var td = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (td != null)
            {
                _dbContext.Tasks.Remove(td);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Task> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }

        public Task GetById(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public Task Update(int id, Task entity)
        {
            var td = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (td != null)
            {
                td.Name = entity.Name;
                td.Description = entity.Description;
                td.StartDate = entity.StartDate;
                td.EndDate = entity.EndDate;
                td.Status = entity.Status;
                _dbContext.SaveChanges();
            }

            return td;
        }

        public void AddTaskToDoList(int toDoListId, Task task)
        {
            ToDoList toDoList = _dbContext.ToDoLists.FirstOrDefault(t => t.Id == toDoListId);
            if (toDoList != null)
            {
                toDoList.Tasks.Add(task);
                _dbContext.SaveChanges();
            }
        }
    }
}
