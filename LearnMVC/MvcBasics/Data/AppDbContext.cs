using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcBasics.Models;

namespace MvcBasics.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
    public DbSet<Race> Races { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        AddressSeed.SeedData(builder);
        UserSeed.SeedData(builder);
        ClubSeed.SeedData(builder);
        RaceSeed.SeedData(builder);
    }
}
