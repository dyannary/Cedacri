using Microsoft.AspNetCore.Mvc;

namespace MvcBasics.Controllers;

public class ClubController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


}
