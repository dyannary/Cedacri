﻿using MedicalApp.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace Models.Context;

public class DataSeed
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        SeedDoctors(modelBuilder);
        SeedPatients(modelBuilder);
        SeedDoctorPatients(modelBuilder);
    }

    private static void SeedDoctors(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor()
            {
                Ident = 1,
                Name = "User1",
                Username = "Test1",
                Email = "user1@mail.com",
            }
        );
    }

    private static void SeedPatients(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().HasData(
            new Patient()
            {
                Id = 1,
                Name = "TestPatient1",
                Email = "user@mail.com",
                Phone = "03982821",
                Idnp = "32434323131"
            }
        );
    }

    private static void SeedDoctorPatients(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorPatient>().HasData(
            new DoctorPatient()
            {
                DoctorId = 1,
                PatientId = 1
            }
        );
    }
}
