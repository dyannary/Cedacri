﻿using MvcBasics.Models;

namespace MvcBasics.Interfaces;

public interface IClubRepository
{
    Task<IEnumerable<Club>> GetAll();
    Task<Club> GetClubByIdAsync(int id);
    Task<IEnumerable<Club>> GetClubByCity(string city);
    bool Add(Club club);
    bool Update(Club club);  
    bool Delete(Club club);
    bool Save();
}
