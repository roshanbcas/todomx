namespace ToDoList.Entities
{
    public class UserToDoList
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int TodoListId { get; set; }
        public ToDoList? ToDoList { get; set; }
    }
}
