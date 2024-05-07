using MedicalApp.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Domain;

namespace MedicalApp.Console.Data;

public class AppDbContext : DbContext
{
    const string connectionString = "Server=CEDINT874\\SQLEXPRESS;Database=MedicalApp;trusted_connection=true;Encrypt=False";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<DoctorPatient> DoctorPatients { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<AdditionalInfo> AdditionalInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DoctorPatient>()
        .HasKey(dp => new { dp.DoctorId, dp.PatientId });

        modelBuilder.Entity<Patient>()
            .Ignore(u => u.Address)
            .ToTable("Pacient");

        modelBuilder.Entity<Patient>()
            .Property(i => i.Id)
            .HasColumnName("patient_id");

        modelBuilder.Entity<Patient>()
            .HasMany(e => e.Doctors)
            .WithMany(e => e.Patients)
            .UsingEntity<DoctorPatient>();

        modelBuilder.Entity<Patient>()
            .HasOne(e => e.Info)
            .WithOne(e => e.Patient)
            .HasForeignKey<AdditionalInfo>(e => e.Id)
            .IsRequired();

        modelBuilder.Entity<Doctor>()
            .HasKey(d => d.Ident)
            .HasName("DoctorsPrimaryKey");

        modelBuilder.Entity<Doctor>()
            .Property(e => e.Username)
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        modelBuilder.Entity<Doctor>()
            .Property(n => n.Name)
            .HasMaxLength(50);

        modelBuilder.Entity<DoctorPatient>()
            .HasKey(u => new { u.PatientId, u.DoctorId });

        modelBuilder.Ignore<AdditionalInfo>();

        DataSeed.SeedData(modelBuilder);
    }
}