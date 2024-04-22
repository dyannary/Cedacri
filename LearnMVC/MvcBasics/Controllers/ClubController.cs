using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using MvcBasics.Dtos.Club;
using MvcBasics.Interfaces;
using MvcBasics.Models;

namespace MvcBasics.Controllers;

public class ClubController : Controller
{
    private readonly IClubRepository _clubRepository;
    private readonly IPhotoService _photoService;

    public ClubController(IClubRepository clubRepository, IPhotoService photoService)
    {
        _clubRepository = clubRepository;
        _photoService = photoService;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _clubRepository.GetAll());
    }

    public async Task<IActionResult> Detail(int id)
    {
        var club = await _clubRepository.GetByIdAsync(id);

        return View(club);
    }

    public IActionResult Create()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClubDto clubDto)
    {
        if(ModelState.IsValid)
        {
            var result = await _photoService.AddPhotoAsync(clubDto.Image);
            var club = new Club
            {
                Title = clubDto.Title,
                Description = clubDto.Description,
                ClubCategory = clubDto.ClubCategory,
                Image = result.Url.ToString(),
                Address = new Address
                {
                    Street = clubDto.Address.Street,
                    City = clubDto.Address.City,
                    State = clubDto.Address.State
                }
            };
            _clubRepository.Add(club);
            return RedirectToAction("Index");
        }
        else
        {
            ModelState.AddModelError("", "Photo upload failed");
        }
        return View(clubDto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var club = await _clubRepository.GetByIdAsync(id);
        if(club is null)
            return View(id);

        var clubDto = new EditClubDto
        {
            Title = club.Title,
            Description = club.Description,
            AddressId = club.AddressId,
            Address = club.Address,
            Url = club.Image,
            ClubCategory = club.ClubCategory
        };
        return View(clubDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditClubDto clubDto)
    {
        if(!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Failed to edit club");
            return View("Edit", clubDto);
        }

        var userClub = await _clubRepository.GetByIdAsyncNoTracking(id);

        if(userClub != null)
        {
            try
            {
                await _photoService.DeletePhotoAsync(userClub.Image);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Could not delete photo");
                return View(clubDto);
            }
            var photoResult = await _photoService.AddPhotoAsync(clubDto.Image);

            var club = new Club
            {
                Id = id,
                Title = clubDto.Title,
                Description = clubDto.Description,
                Image = photoResult.Url.ToString(),
                AddressId = clubDto.AddressId,
                Address = clubDto.Address,
                ClubCategory = clubDto.ClubCategory
            };
            _clubRepository.Update(club);
            return RedirectToAction("Index");
        }
        else
        {
            return View(clubDto);
        }
    }
}
