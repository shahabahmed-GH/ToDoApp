using Microsoft.EntityFrameworkCore;
namespace TodoListApp.Models

{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isCompleted { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
