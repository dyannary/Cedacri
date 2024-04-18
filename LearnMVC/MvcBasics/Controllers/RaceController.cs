using Microsoft.AspNetCore.Mvc;
using MvcBasics.Data;

namespace MvcBasics.Controllers
{
    public class RaceController : Controller
    {
        private readonly AppDbContext _context;
        public RaceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Races.ToList());
        }
    }
}
