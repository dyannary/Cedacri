namespace NotesApp.Domain.Entities;

public class NoteTag
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    public int NoteId { get; set; }
    public Note Note { get; set; }
}
