using ToDoList.Entities;

namespace ToDoList.Repositories
{
    public class ToDoListRepository : IRepository<ToDoList>
    {
        private readonly ToDoListDbContext _dbContext;
        public ToDoListRepository(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ToDoList Create(ToDoList entity)
        {
            _dbContext.ToDoLists.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var td = _dbContext.ToDoLists.FirstOrDefault(t => t.Id == id);
            if (td != null)
            {
                _dbContext.ToDoLists.Remove(td);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<ToDoList> GetAll()
        {
            return _dbContext.ToDoLists.ToList();
        }

        public ToDoList GetById(int id)
        {
            return _dbContext.ToDoLists.FirstOrDefault(t => t.Id == id);
        }

        public ToDoList Update(int id, ToDoList entity)
        {
            var td = _dbContext.ToDoLists.FirstOrDefault(t => t.Id == id);
            if (td != null)
            {
                td.Name = entity.Name;
                td.Description = entity.Description;
                _dbContext.SaveChanges();
            }

            return td;
        }



        public IEnumerable<ToDoList> GetToDoListsForUser(int userId)
        {
            return _dbContext.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.UserToDoLists.Select(utl => utl.ToDoList))
                .ToList();
        }

        public void AddToDoListToUser(int userId, int toDoListId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            var toDoList = _dbContext.ToDoLists.FirstOrDefault(t => t.Id == toDoListId);

            if (user != null && toDoList != null)
            {
                user.UserToDoLists.Add(new UserToDoList { User = user, ToDoList = toDoList });
                _dbContext.SaveChanges();
            }
        }
    }
}
