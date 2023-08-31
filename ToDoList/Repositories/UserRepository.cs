using ToDoList.Entities;

namespace ToDoList.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ToDoListDbContext _dbContext;

        public UserRepository(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Create(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var u1 = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (u1 != null)
            {
                _dbContext.Users.Remove(u1);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Update(int id, User entity)
        {
            var u1 = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (u1 != null)
            {
                u1.FirstName = entity.FirstName;
                u1.LastName = entity.LastName;
                u1.Gender = entity.Gender;
                u1.Email = entity.Email;
                _dbContext.SaveChanges();
            }

            return u1;
        }
    }
}
