﻿using MvcBasics.Data.Enum;
using MvcBasics.Models;

namespace MvcBasics.Dtos.Race;

public class CreateRaceDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Address Address { get; set; }
    public IFormFile Image { get; set; }
    public RaceCategory RaceCategory { get; set; }
}
