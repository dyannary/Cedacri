using NotesApp.Domain.Enums;

namespace NotesApp.Domain.Entities;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public DateTime CreationDate { get; set; }   
    public DateTime Deadline { get; set; }
    public bool IsCompleted { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
