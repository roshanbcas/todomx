using ToDoList.Entities;

namespace ToDoList
{
    public class ToDoList : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<UserToDoList> UserToDoLists { get; set; } = new List<UserToDoList>();
        public ICollection<Task> Tasks { get; set; } = new List<Task>();

    }
}
