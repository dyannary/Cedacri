using Microsoft.EntityFrameworkCore;
using MvcBasics.Data;
using MvcBasics.Interfaces;
using MvcBasics.Models;

namespace MvcBasics.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly AppDbContext _context;
        public RaceRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Race club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Race club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race> GetRaceByIdAsync(int id)
        {
            return await _context.Races.Include(i => i.Address).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Race>> GetRacesByCity(string city)
        {
            return await _context.Races.Where(c=>c.Address.City.Contains(city)).ToListAsync(); 
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race club)
        {
            _context.Update(club);
            return Save();
        }
    }
}
