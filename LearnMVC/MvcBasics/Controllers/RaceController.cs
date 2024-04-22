using Microsoft.AspNetCore.Mvc;
using MvcBasics.Dtos.Race;
using MvcBasics.Interfaces;
using MvcBasics.Models;

namespace MvcBasics.Controllers;

public class RaceController : Controller
{
    private readonly IRaceRepository _raceRepository;
    private readonly IPhotoService _photoService;
    public RaceController(IRaceRepository raceRepository, IPhotoService photoService)
    {
        _raceRepository = raceRepository;
        _photoService = photoService;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _raceRepository.GetAll());
    }

    public async Task<IActionResult> Detail(int id)
    {
        var race = await _raceRepository.GetByIdAsync(id);

        return View(race);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRaceDto raceDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _photoService.AddPhotoAsync(raceDto.Image);

            var race = new Race
            {
                Title = raceDto.Title,
                Description = raceDto.Description,
                RaceCategory = raceDto.RaceCategory,
                Image = result.Url.ToString(),
                Address = new Address
                {
                    Street = raceDto.Address.Street,
                    City = raceDto.Address.City,
                    State = raceDto.Address.State
                }
            };
            _raceRepository.Add(race);
            return RedirectToAction("Index");
        }
        return View(raceDto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var race = await _raceRepository.GetByIdAsync(id);
        if (race is null)
            return View(id);

        var raceDto = new EditRaceDto
        {
            Title = race.Title,
            Description = race.Description,
            AddressId = race.AddressId,
            Address = race.Address,
            Url = race.Image,
            RaceCategory = race.RaceCategory
        };
        return View(raceDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditRaceDto raceDto)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Failed to edit race");
            return View("Edit", raceDto);
        }

        var userRace = await _raceRepository.GetByIdAsyncNoTracking(id);

        if (userRace != null)
        {
            try
            {
                await _photoService.DeletePhotoAsync(userRace.Image);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Could not delete photo");
                return View(raceDto);
            }
            var photoResult = await _photoService.AddPhotoAsync(raceDto.Image);

            var race = new Race
            {
                Id = id,
                Title = raceDto.Title,
                Description = raceDto.Description,
                Image = photoResult.Url.ToString(),
                AddressId = raceDto.AddressId,
                Address = raceDto.Address,
                RaceCategory = raceDto.RaceCategory
            };
            _raceRepository.Update(race);
            return RedirectToAction("Index");
        }
        else
        {
            return View(raceDto);
        }
    }
}
