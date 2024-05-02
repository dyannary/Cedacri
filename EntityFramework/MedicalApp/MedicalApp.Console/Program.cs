using MedicalApp.Console.Data;
using MedicalApp.Console.Domain;
using MedicalApp.Console.Repository;

var dbContext = new AppDbContext();

var doctorRepository = new DoctorRepository(dbContext);

Console.WriteLine("Doctors: ");

var doctors = doctorRepository.GetAll();

Console.WriteLine("Add a doctor: ");

var doctor = new Doctor
{
    Name = "Diana",
    Username = "root",
    Email = "root@mail.com",
};

var doctor2 = new Doctor
{
    Name = "Diana",
    Username = "root",
    Email = "root@mail.com",
};

doctorRepository.Add(doctor);
doctorRepository.Add(doctor2);


//foreach (var d in doctors)
//{
//    Console.WriteLine($"Doctor ID: {d.Id}, Name: {d.Name}, Username: {d.Username}, Email: {d.Email}");
//}

//doctorRepository.Edit(doctor);

//foreach (var d in doctors)
//{
//    Console.WriteLine($"Doctor ID: {d.Id}, Name: {d.Name}, Username: {d.Username}, Email: {d.Email}");
//}


//doctorRepository.Delete(doctor2);

//foreach (var d in doctors)
//{
//    Console.WriteLine($"Doctor ID: {d.Id}, Name: {d.Name}, Username: {d.Username}, Email: {d.Email}");
//}

Console.Read();