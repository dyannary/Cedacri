using MedicalApp.Console.Data;
using MedicalApp.Console.Domain;
using MedicalApp.Console.Repository;
using System.ComponentModel.DataAnnotations;

var dbContext = new AppDbContext();

var doctorRepository = new DoctorRepository(dbContext);

Console.WriteLine("Doctors: ");

var doctors = doctorRepository.GetAll();

Console.WriteLine("Add a doctor: ");

using (AppDbContext db = new AppDbContext())
{
    var doctor = new Doctor
    {
        Name = "Diana",
        Username = "root",
        Email = "diana.r1@mail.com",
        Patients = new List<Patient>
        {
            new Patient
            {
                Name = "TestPatient2",
                Email = "teste2",
                Phone = "069817722",
                Idnp = "123456789123"
            }
        }
    };

    var validationContext = new ValidationContext(doctor);
    var validationResults = new List<ValidationResult>();
    if (!Validator.TryValidateObject(doctor, validationContext, validationResults, true))
    {
        foreach (var validationResult in validationResults)
        {
            Console.WriteLine(validationResult.ErrorMessage);
        }
    }
    else
    {
        doctorRepository.Add(doctor);
       // doctorRepository.Edit(4);

        foreach (var d in doctors)
        {
            Console.WriteLine($"Doctor ID: {d.Ident}, Name: {d.Name}, Username: {d.Username}, Email: {d.Email}");
        }
    }

    //foreach (var d in doctors)
    //{
    //    Console.WriteLine($"Doctor ID: {d.Ident}, Name: {d.Name}, Username: {d.Username}, Email: {d.Email}");
    //}
}

var doctor2 = new Doctor
{
    Name = "Diana",
    Username = "root",
    Email = "root@mail.com",
};

//doctorRepository.Add(doctor);
//doctorRepository.Add(doctor2);


//foreach (var d in doctors)
//{
//    Console.WriteLine($"Doctor ID: {d.Id}, Name: {d.Name}, Username: {d.Username}, Email: {d.Email}");
//}

//doctorRepository.Edit(doctor);

//foreach (var d in doctors)
//{
//    Console.WriteLine($"Doctor ID: {d.Id}, Name: {d.Name}, Username: {d.Username}, Email: {d.Email}");
//}

//doctorRepository.Delete(7);

//foreach (var d in doctors)
//{
//    Console.WriteLine($"Doctor ID: {d.Ident}, Name: {d.Name}, Username: {d.Username}, Email: {d.Email}");
//}

Console.Read();