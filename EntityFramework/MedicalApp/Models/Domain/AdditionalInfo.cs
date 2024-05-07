using MedicalApp.Console.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain;

[NotMapped]
public class AdditionalInfo
{
    [Column("info_id")]
    public int Id { get; set; }
    [MaxLength(500)]
    public string PatientInfoDetaild { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
}
