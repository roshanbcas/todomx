using Microsoft.AspNetCore.Mvc;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : BaseController<ToDoListRepository>
    {
        public ToDoListController(BaseRepository<ToDoListRepository> repository) : base(repository)
        {
        }
    }
}
