using Microsoft.AspNetCore.Mvc;
using MvcBasics.Data;

namespace MvcBasics.Controllers;

public class ClubController : Controller
{
    private readonly AppDbContext _context;
    public ClubController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.Clubs.ToList());
    }
}
