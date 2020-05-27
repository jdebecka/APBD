using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApplication.Entities
{
    public class DoctorDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
        public DoctorDbContext() { }

        public DoctorDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired();

                entity.ToTable("Doctor");

                entity.HasMany(e => e.Prescriptions)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey(p => p.IdDoctor)
                    .IsRequired();
            });
            
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription);
                entity.Property(p => p.IdPrescription).ValueGeneratedOnAdd();

                entity.ToTable("Prescription");

                entity.HasMany(p => p.Prescription_Medicament)
                    .WithOne(p => p.Prescription)
                    .HasForeignKey(p => p.IdPrescription)
                    .IsRequired();

            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.IdPatient);
                entity.Property(p => p.IdPatient).ValueGeneratedOnAdd();

                entity.ToTable("Patient");

                entity.HasMany(p => p.Prescriptions)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(p => p.IdPatient)
                    .IsRequired();

            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(p => p.IdMedicament).ValueGeneratedOnAdd();

                entity.ToTable("Medicament");

                entity.HasMany(p => p.Prescription_Medicament)
                    .WithOne(p => p.Medicament)
                    .HasForeignKey(p => p.IdMedicament)
                    .IsRequired();
            });

            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(p => new {p.IdMedicament, p.IdPrescription});
                entity.Property(p => p.IdMedicament).IsRequired();
                entity.Property(p => p.IdPrescription).IsRequired();

                entity.HasOne(p => p.Medicament)
                    .WithMany(p => p.Prescription_Medicament)
                    .HasForeignKey(p => p.IdMedicament);
                
                entity.HasOne(p => p.Prescription)
                    .WithMany(p => p.Prescription_Medicament)
                    .HasForeignKey(p => p.IdPrescription);

            });
            
             Seed(modelBuilder);
        }
        static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { IdDoctor = 1, FirstName = "Julia", LastName = "Debecka", Email = "jdebecka@gmail.com"},
                new Doctor { IdDoctor = 2, FirstName = "Kamil", LastName = "Sikora", Email = "ksikora@gmail.com"},
                new Doctor { IdDoctor = 3, FirstName = "Parker", LastName = "Hicks", Email = "pHicks@gmail.com"}
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient{IdPatient = 1, FirstName= "Lolek", LastName="Folek", Birthdate = new DateTime(1997, 04, 02)},
                new Patient{IdPatient = 2, FirstName = "Jola", LastName = "Mola", Birthdate = new DateTime(1993, 01, 23)},
                new Patient{ IdPatient = 3, FirstName = "Henio", LastName = "Lenio", Birthdate = new DateTime(1977, 12, 13)},
                new Patient{ IdPatient = 4, FirstName = "Mania", LastName = "Frania", Birthdate = new DateTime(1994, 12, 02) }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription{ IdPrescription = 1, Date = new DateTime(2020, 04, 02),DueDate = new DateTime(2020, 04, 12), IdPatient = 1, IdDoctor = 1},
                new Prescription{ IdPrescription = 2, Date = new DateTime(2020, 03, 02),DueDate = new DateTime(2020, 04, 12), IdPatient = 2, IdDoctor = 2},
                new Prescription{ IdPrescription = 3, Date = new DateTime(2019, 12, 02),DueDate = new DateTime(2020, 04, 12), IdPatient = 1, IdDoctor = 2},
                new Prescription{ IdPrescription = 4, Date = new DateTime(2020, 04, 02),DueDate = new DateTime(2020, 04, 12), IdPatient = 4, IdDoctor = 3},
                new Prescription{ IdPrescription = 5, Date = new DateTime(2020, 04, 02),DueDate = new DateTime(2020, 04, 12), IdPatient = 2, IdDoctor = 3}
            );

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament{ IdMedicament = 1,Name ="Xanax", Description = "Very good medication", Type = "Amazing"},
                new Medicament{ IdMedicament = 2,Name ="Seronil", Description = "Very good good medication", Type = "Amazing"},
                new Medicament{ IdMedicament = 3,Name ="Aspirin", Description = "Very medication", Type = "Fever"}
            );

            modelBuilder.Entity<Prescription_Medicament>().HasData(
                
                new Prescription_Medicament{ IdMedicament = 1, IdPrescription = 1, Dose = 2, Details = "As much as you need"},
                new Prescription_Medicament{ IdMedicament = 2, IdPrescription = 2, Dose =4, Details = "As much as you need"},
                new Prescription_Medicament{ IdMedicament = 1, IdPrescription = 3, Dose = 4, Details = "As much as you need"}
            );
        }
    }
}