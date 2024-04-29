namespace MedicalApp.Console.Domain;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Idnp { get; set; } = string.Empty;
    public ICollection<DoctorPacient> DoctorPacients { get; }
    public ICollection<Doctor> Doctors { get; } = [];
}
