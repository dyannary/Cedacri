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
    public ICollection<Doctor> GetAll()
    {
        return _context.Doctors.ToList();
    }

    public Doctor? GetDoctorById(int id)
    {
        var doctor = _context.Doctors.FirstOrDefault(x => x.Ident == id);

        if (doctor is null)
            return null;

        return doctor;
    }

    public bool Add(Doctor doctor)
    {
        _context.Add(doctor);
        return Save();
    }

    public bool Edit(int id)
    {
        var updated = _context.Doctors.FirstOrDefault(x => x.Ident == id);
        if (updated != null)
        {
            updated.Name = "Bob";
            updated.Username = "bob";
            updated.Email = "bob@mail.com";
            Save();
        }
        return false;
    }

    public bool Delete(int id)
    {
        _context.Doctors.Where(d => d.Ident == id).ExecuteDelete();
        
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}
