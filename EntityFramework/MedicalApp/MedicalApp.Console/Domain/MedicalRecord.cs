namespace MedicalApp.Console.Domain;

public class MedicalRecord
{
    public int Id { get; set; }
    public int PacientId {  get; set; }
    public DateTime? RecordDate { get; set; }
    public string Details { get; set; } = string.Empty;
    public string Treatment { get; set; } = string.Empty;
}
