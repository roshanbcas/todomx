using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController <T> : ControllerBase
    {
        protected readonly BaseRepository<T> _repository;

        public BaseController(BaseRepository<T> repository)
        {
            _repository = repository;
        }


        // POST
        [HttpPost]
        public virtual ActionResult<T> Create([FromBody] T entity)
        {
            var createdEntity = _repository.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.id }, createdEntity);
        }

        // UPDATE
        [HttpPut("{id}")]
        public virtual ActionResult<T> Update(int id, [FromBody] T entity)
        {
            if( id != entity.Id )
            {
                return BadRequest();
            }

            var updatedEntity = _repository.Update(id, entity);
            return Ok(updatedEntity);
        }

        // DELETE
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }

        // GET ALL
        [HttpGet]
        public virtual ActionResult<IEnumerable<T>> GetAll()
        {
            var entities = _repository.GetAll();
            return Ok(entities);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public virtual ActionResult<T> GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
    }
}
