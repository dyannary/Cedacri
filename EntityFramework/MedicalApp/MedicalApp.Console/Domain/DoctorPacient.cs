using System.ComponentModel.DataAnnotations;

namespace MedicalApp.Console.Domain;

public class DoctorPacient
{
    [Key]
    public int DoctorId { get; set; }
    [Key]
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}
