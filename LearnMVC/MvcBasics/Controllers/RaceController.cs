using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcBasics.Data;
using MvcBasics.Interfaces;
using MvcBasics.Models;
using MvcBasics.Repository;

namespace MvcBasics.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _raceRepository.GetAll());
        }

        public async Task<IActionResult> Detail(int id)
        {
            var race = await _raceRepository.GetRaceByIdAsync(id);

            return View(race);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _raceRepository.Add(race);
            return RedirectToAction("Index");
        }
    }
}
