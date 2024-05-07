namespace MedicalApp.Console.Domain;

public class DoctorPatient
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
}
