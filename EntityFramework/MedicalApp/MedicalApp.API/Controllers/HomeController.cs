using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.API.Controllers;

[Route("api/posts")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly DbContext _context;
    public HomeController(DbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<IActionResult>> GetAll()
    {
        var result = await _context.FindAsync<IActionResult>();

        return (IEnumerable<IActionResult>)Ok(result);
    }
}
