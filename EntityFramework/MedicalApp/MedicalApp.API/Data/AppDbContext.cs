using MedicalApp.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<DoctorPatient> DoctorPatients { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DoctorPatient>()
        .HasKey(dp => new { dp.DoctorId, dp.PatientId });

        modelBuilder.Entity<Doctor>()
            .HasMany(e => e.Patients)
            .WithMany(e => e.Doctors);

        DataSeed.SeedData(modelBuilder);
    }
}
