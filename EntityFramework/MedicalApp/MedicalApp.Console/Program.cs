using MedicalApp.Console.Data;
using MedicalApp.Console.Repository;
using Microsoft.EntityFrameworkCore;

var dbContext = new AppDbContext();

Console.WriteLine("Doctors: ");

DoctorRepository doctorRepository = new DoctorRepository(dbContext);

var doctors = doctorRepository.GetAll();

foreach (var doctor in doctors)
{
    Console.WriteLine($"Doctor ID: {doctor.Id}, Name: {doctor.Name}, Username: {doctor.Username}, Email: {doctor.Email}");
}