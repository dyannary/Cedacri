namespace MedicalApp.Console.Domain;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public ICollection<DoctorPacient> DoctorPacients { get; }
    public ICollection<Patient> Patients { get; set; } = [];
}
