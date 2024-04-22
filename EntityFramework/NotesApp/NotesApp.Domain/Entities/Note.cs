using NotesApp.Domain.Enums;

namespace NotesApp.Domain.Entities;

public class Note
{
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; } = string.Empty;
    public DateTime CreationDate {  get; set; } = DateTime.Now;
    public DateTime LastModified { get; set;} = DateTime.Now;
    public ICollection<NoteTag>? NoteTags { get; set; } = new List<NoteTag>();
    public Priority Priority { get; set; }
    public DateTime? Remainder { get; set; } = DateTime.Now;
    public ICollection<Attachments>? Attachments { get; set; }
}
