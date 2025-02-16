using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
