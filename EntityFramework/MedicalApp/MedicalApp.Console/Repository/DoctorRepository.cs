using MedicalApp.Console.Data;
using MedicalApp.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Console.Repository;

public class DoctorRepository
{
    private readonly AppDbContext _context;
    public DoctorRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool Add(Doctor doctor)
    {
        _context.Add(doctor);
        return Save();
    }

    public bool Delete(Doctor doctor)
    {
        _context.Remove(doctor);
        return Save();
    }

    public ICollection<Doctor> GetAll()
    {
        return _context.Doctors.ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}
