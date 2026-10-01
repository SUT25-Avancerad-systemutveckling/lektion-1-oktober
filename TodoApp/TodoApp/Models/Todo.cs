namespace TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsComplete { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
