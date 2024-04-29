namespace MedicalApp.Console.Domain;

public class Recipe
{
    public int Id { get; set; }
    public int PacientId { get; set; }
    public string Drug { get; set; }
    public string Dose { get; set; }
    public DateTime PrescriptionDate {  get; set; }
}
