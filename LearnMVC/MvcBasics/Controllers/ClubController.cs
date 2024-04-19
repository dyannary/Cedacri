using Microsoft.AspNetCore.Mvc;
using MvcBasics.Data;
using MvcBasics.Interfaces;
using MvcBasics.Models;

namespace MvcBasics.Controllers;

public class ClubController : Controller
{
    private readonly IClubRepository _clubRepository;

    public ClubController(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _clubRepository.GetAll());
    }

    public async Task<IActionResult> Detail(int id)
    {
        var club = await _clubRepository.GetClubByIdAsync(id);

        return View(club);
    }

    public IActionResult Create()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> Create(Club club)
    {
        if(!ModelState.IsValid)
        {
            return View();
        }
        _clubRepository.Add(club);
        return RedirectToAction("Index");
    }
}
