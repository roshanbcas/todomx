using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;

namespace ToDoList
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<UserToDoList> userToDoLists { get; set; }
    }
}
