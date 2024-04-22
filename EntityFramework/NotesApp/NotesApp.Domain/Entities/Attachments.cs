using NotesApp.Domain.Enums;

namespace NotesApp.Domain.Entities;

public class Attachments
{
    public string Name { get; set; } = string.Empty;
    public FileType FileType { get; set; }  
    public string? FileUrl {  get; set; }
}
