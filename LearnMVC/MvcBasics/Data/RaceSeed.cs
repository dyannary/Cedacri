using Microsoft.EntityFrameworkCore;
using MvcBasics.Data.Enum;
using MvcBasics.Models;

namespace MvcBasics.Data;

public class RaceSeed
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race>().HasData(
            new Race()
            {
                Id = 2, 
                UserId = 1,
                Title = "Running Race 1",
                Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                Description = "This is the description of the first race",
                RaceCategory = RaceCategory.Marathon,
                AddressId = 1
            },
            new Race()
            {
                Id = 3,
                UserId = 1,
                Title = "Running Race 2",
                Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                Description = "This is the description of the first race",
                RaceCategory = RaceCategory.Ultra,
                AddressId = 2
            });
    }
}
