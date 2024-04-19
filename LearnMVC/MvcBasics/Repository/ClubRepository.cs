using Microsoft.EntityFrameworkCore;
using MvcBasics.Data;
using MvcBasics.Interfaces;
using MvcBasics.Models;

namespace MvcBasics.Repository;

public class ClubRepository : IClubRepository
{
    private readonly AppDbContext _context;
    public ClubRepository(AppDbContext context)
    {
        _context = context;
    }
    public bool Add(Club club)
    {
        _context.Add(club);
        return Save();
    }

    public bool Delete(Club club)
    {
        _context.Remove(club);
        return Save();
    }

    public async Task<IEnumerable<Club>> GetAll()
    {
        return await _context.Clubs.ToListAsync();
    }

    public async Task<Club> GetClubByIdAsync(int id)
    {
        return await _context.Clubs.Include(i=>i.Address).FirstOrDefaultAsync(i=>i.Id == id);
    }
    public async Task<IEnumerable<Club>> GetClubByCity(string city)
    {
        return await _context.Clubs.Where(c => c.Address!.City.Contains(city)).ToListAsync();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool Update(Club club)
    {
        _context.Update(club);
        return Save();  
    }
}
