using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TodoListAPI.Models;
using TodoListModels;

namespace TodoListAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemsController : ControllerBase
{
        private readonly TodoDBContext _context;

        public TodoItemsController(TodoDBContext context)
        {
            _context = context;
        }

        
        [HttpGet("NoCompletedDate")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetTodoItemsWithNoCompletedDate()
        {
            var todoItems = await _context.TodoItems
                .Where(item => item.CompletedDate == null)
                .ToListAsync();

            if (todoItems == null || !todoItems.Any())
            {
                return NotFound();
            }

            return todoItems;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }   

        
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostTodoItem(ToDoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        
        [HttpPost("Complete/{id}")]
        public async Task<IActionResult> CompleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.CompletedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return NoContent();
        }

}