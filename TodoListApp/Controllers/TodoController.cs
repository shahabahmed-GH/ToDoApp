using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // Show all todos
        public IActionResult Index()
        {
            var todos = _context.TodoItems.ToList();
            return View(todos);
        }

        // Add new todo
        [HttpPost]
        public IActionResult Create(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                _context.TodoItems.Add(new TodoItem
                {
                    Title = title,
                    isCompleted = false
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Mark complete/incomplete
        public IActionResult Toggle(int id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo != null)
            {
                todo.isCompleted = !todo.isCompleted;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Delete todo
        public IActionResult Delete(int id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}