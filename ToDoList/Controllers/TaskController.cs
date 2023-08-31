using Microsoft.AspNetCore.Mvc;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : BaseController<TaskRepository>
    {
        public TaskController(BaseRepository<TaskRepository> repository) : base(repository)
        {
        }
    }
}
