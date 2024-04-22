using NotesApp.Domain.Enums;

namespace NotesApp.Domain.Entities;

public class Attachment
{
    public string Name { get; set; } = string.Empty;
    public FileType FileType { get; set; }  
    public string? FileUrl {  get; set; }
    public int NoteId { get; set; }
    public Note Note { get; set; }
}
