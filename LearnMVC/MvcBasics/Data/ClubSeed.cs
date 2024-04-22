using Microsoft.EntityFrameworkCore;
using MvcBasics.Data.Enum;
using MvcBasics.Models;

namespace MvcBasics.Data;

public class ClubSeed
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Club>().HasData(
        new Club()
        {
            Id = 5,
            UserId = 1,
            Title = "Running Club 1",
            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
            Description = "This is the description of the first cinema",
            ClubCategory = ClubCategory.City,
            AddressId = 1
        },
        new Club()
        {
            Id = 6,
            UserId = 1,
            Title = "Running Club 2",
            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
            Description = "This is the description of the first cinema",
            ClubCategory = ClubCategory.Endurance,
            AddressId = 2
        },
        new Club()
        {
            Id = 7,
            UserId = 1,
            Title = "Running Club 3",
            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
            Description = "This is the description of the first club",
            ClubCategory = ClubCategory.Trail,
            AddressId = 2
        },
        new Club()
        {
            Id = 8,
            UserId = 1,
            Title = "Running Club 3",
            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
            Description = "This is the description of the first club",
            ClubCategory = ClubCategory.City,
            AddressId = 1
        });;
    }
}
