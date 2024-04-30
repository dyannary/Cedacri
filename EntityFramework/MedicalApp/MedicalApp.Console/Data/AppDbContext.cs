using MedicalApp.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace MedicalApp.Console.Data;

public class AppDbContext : DbContext
{
    const string connectionString = "Server=CEDINT874\\SQLEXPRESS;Database=MedicalApp;trusted_connection=true;Encrypt=False";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        //optionsBuilder.LogTo(System.Console.WriteLine);
        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
    }
    private readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<DoctorPacient> DoctorPatients { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Recipe> Recipes { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DoctorPacient>()
        .HasKey(dp => new { dp.DoctorId, dp.PatientId });

        modelBuilder.Entity<Doctor>()
            .HasMany(e => e.Patients)
            .WithMany(e => e.Doctors);

        DataSeed.SeedData(modelBuilder);
    }
}