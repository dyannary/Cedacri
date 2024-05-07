using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApp.Console.Domain;

public class Recipe
{
    public int Id { get; set; }
    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    public string Drug { get; set; } = null!;
    public string Dose { get; set; } = null!;
    public DateTime PrescriptionDate {  get; set; }
}
