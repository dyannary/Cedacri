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

    public bool Edit(Doctor doctor)
    {
        var result = _context.Doctors.FirstOrDefault();
        if(result != null)
        {
            result.Name = "Bob";
            result.Username = "bob";
            result.Email = "bob@mail.com";
            Save();
        }
        return false;
    }

    public bool Delete(Doctor doctor)
    {
        _context.Remove(doctor);
        return Save();
    }

    public async Task<ICollection<Doctor>> GetAll()
    {
        return await _context.Doctors.ToListAsync();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}
