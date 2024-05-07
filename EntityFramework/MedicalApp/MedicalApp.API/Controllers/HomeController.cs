using MedicalApp.API.Data;
using MedicalApp.Console.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Models.Dtos;

namespace MedicalApp.API.Controllers;

[Route("api/posts")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
   // [ProducesResponseType(typeof(IEnumerable<string>), 200)]
    public ActionResult<IEnumerable<Doctor>> GetAll()
    {
        var result = _context.Doctors.ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<IEnumerable<Doctor>> GetDoctorById(int id)
    {
        var doctor = _context.Doctors.FirstOrDefault(x => x.Ident == id);

        if (doctor is null)
        {
            return NotFound();
        }

        return Ok(doctor);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<string>), 200)]
    public ActionResult AddPost(AddEditDoctorDto doctorDto)
    {
        var doctor = new Doctor
        {
            Name = doctorDto.Name,
            Username = doctorDto.Username,
            Email = doctorDto.Email,
        };
        _context.Add(doctor);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public ActionResult? EditPost(int id, AddEditDoctorDto toUpdate)
    {
        var updatedDoctor = _context.Doctors.FirstOrDefault(x => x.Ident == id);

        if (updatedDoctor is null)
            return null;

        if (!string.IsNullOrEmpty(toUpdate.Name))
        {
            updatedDoctor.Name = toUpdate.Name;
        }

        if (!string.IsNullOrEmpty(toUpdate.Username))
        {
            updatedDoctor.Username = toUpdate.Username;
        }

        if (!string.IsNullOrEmpty(toUpdate.Email))
        {
            updatedDoctor.Email = toUpdate.Email;
        }

        _context.SaveChangesAsync();
        return Ok(updatedDoctor);
    }

    [HttpDelete("{id}")]
    public ActionResult? Delete([FromRoute] int id)
    {
        var doctor = _context.Doctors.FirstOrDefault(x => x.Ident == id);

        if (doctor is null) 
            return BadRequest("The doctor is not found.");

        var deletedDoctor = _context.Doctors.Remove(doctor);

        _context.SaveChangesAsync();

        return Ok("Doctor was successfully deleted!");
    }
}
