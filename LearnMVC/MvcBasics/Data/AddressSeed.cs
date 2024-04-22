using Microsoft.EntityFrameworkCore;
using MvcBasics.Models;

namespace MvcBasics.Data;

public class AddressSeed
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>().HasData(
        new Address()
        {
            Id = 1,
            Street = "123 Main St",
            City = "Charlotte",
            State = "NC"
        },
        new Address()
        {
            Id = 2,
            Street = "123 Main St",
            City = "Charlotte",
            State = "NC"
        });
    }
}
