using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodosController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var todos = await _context.Todos.AsNoTracking().ToListAsync();
            return Ok(todos);
        }

        public class CreateTodoDto
        {
            public string Title { get; set; } = null!;
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] CreateTodoDto dto)
        {
            var todo = new Todo
            {
                Title = dto.Title,
                IsComplete = false,
                CreatedAt = System.DateTime.UtcNow
            };

            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return Created($"/api/todos/{todo.Id}", todo);
        }
    }
}
