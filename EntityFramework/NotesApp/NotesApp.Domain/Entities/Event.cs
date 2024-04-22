namespace NotesApp.Domain.Entities;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location {  get; set; } = string.Empty;
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
    public bool AllDay {  get; set; }
}
