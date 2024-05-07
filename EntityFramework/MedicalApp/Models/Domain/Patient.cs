using Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApp.Console.Domain;

[Table("Pacient")]
public class Patient
{
    [Key]
    [Column("patient_id")]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Mobile no. is required")]
    [RegularExpression("^0(\\d{8})")]
    public string Phone { get; set; } = null!;
    [Required]
    [StringLength(12)]
    public string Idnp { get; set; } = null!;
    [NotMapped]
    public string? Address { get; set; }
    public ICollection<Doctor> Doctors { get; } = [];
    public ICollection<Recipe> Recipes { get; } = [];   
    public ICollection<MedicalRecord> MedicalRecords { get; } = []; 
    public AdditionalInfo? Info {  get; set; }
}
