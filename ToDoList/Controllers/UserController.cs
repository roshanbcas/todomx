using Microsoft.AspNetCore.Mvc;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController<UserRepository>
    {
        public UserController(BaseRepository<UserRepository> repository) : base(repository)
        {
        }
    }
}
