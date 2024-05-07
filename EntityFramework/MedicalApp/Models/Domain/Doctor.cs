using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApp.Console.Domain;

public class Doctor
{
    [Key]
    [Column("doctor_id")]
    public int Ident { get; set; }
    [Column("doctor_name")]
    public string Name { get; set; } = null!;
    public string Username { get; set; } = null!;
    [Column(TypeName = "varchar(50)")]
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = null!;
    [ForeignKey("DoctorPatient_DoctorId")]
    public int? DoctorId { get; set; }
    [ForeignKey("DoctorPatient_PatientId")]
    public int? PatientId { get; set; }
    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
