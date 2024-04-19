using MvcBasics.Models;

namespace MvcBasics.Interfaces;

public interface IRaceRepository
{
    Task<IEnumerable<Race>> GetAll();
    Task<Race> GetRaceByIdAsync(int id);
    Task<IEnumerable<Race>> GetRacesByCity(string city);
    bool Add(Race club);
    bool Update(Race club);
    bool Delete(Race club);
    bool Save();
}
