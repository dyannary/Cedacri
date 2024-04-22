using MvcBasics.Models;

namespace MvcBasics.Interfaces;

public interface IRaceRepository
{
    Task<IEnumerable<Race>> GetAll();
    Task<Race> GetByIdAsync(int id);
    Task<Race> GetByIdAsyncNoTracking(int id);
    Task<IEnumerable<Race>> GetRacesByCity(string city);
    bool Add(Race club);
    bool Update(Race club);
    bool Delete(Race club);
    bool Save();
}
