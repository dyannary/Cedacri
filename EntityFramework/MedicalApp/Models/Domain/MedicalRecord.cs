using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApp.Console.Domain;

public class MedicalRecord
{
    public int Id { get; set; }
    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    public DateTime RecordDate { get; set; } 
    public string Details { get; set; } = null!;
    public string Treatment { get; set; } = null!;
}
