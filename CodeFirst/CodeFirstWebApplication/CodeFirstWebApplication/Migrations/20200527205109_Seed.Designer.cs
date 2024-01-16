﻿// <auto-generated />
using System;
using CodeFirstWebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirstWebApplication.Migrations
{
    [DbContext(typeof(DoctorDbContext))]
    [Migration("20200527205109_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeFirstWebApplication.Entities.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "jdebecka@gmail.com",
                            FirstName = "Julia",
                            LastName = "Debecka"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "ksikora@gmail.com",
                            FirstName = "Kamil",
                            LastName = "Sikora"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "pHicks@gmail.com",
                            FirstName = "Parker",
                            LastName = "Hicks"
                        });
                });

            modelBuilder.Entity("CodeFirstWebApplication.Entities.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Very good medication",
                            Name = "Xanax",
                            Type = "Amazing"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Very good good medication",
                            Name = "Seronil",
                            Type = "Amazing"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Very medication",
                            Name = "Aspirin",
                            Type = "Fever"
                        });
                });

            modelBuilder.Entity("CodeFirstWebApplication.Entities.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(1997, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lolek",
                            LastName = "Folek"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(1993, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jola",
                            LastName = "Mola"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(1977, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Henio",
                            LastName = "Lenio"
                        },
                        new
                        {
                            IdPatient = 4,
                            Birthdate = new DateTime(1994, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mania",
                            LastName = "Frania"
                        });
                });

            modelBuilder.Entity("CodeFirstWebApplication.Entities.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 2,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 2,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 4,
                            Date = new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 3,
                            IdPatient = 4
                        },
                        new
                        {
                            IdPrescription = 5,
                            Date = new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 3,
                            IdPatient = 2
                        });
                });

            modelBuilder.Entity("CodeFirstWebApplication.Entities.Prescription_Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription");

                    b.HasIndex("IdPrescription");

                    b.ToTable("PrescriptionMedicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "As much as you need",
                            Dose = 2
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 2,
                            Details = "As much as you need",
                            Dose = 4
                        },
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 3,
                            Details = "As much as you need",
                            Dose = 4
                        });
                });

            modelBuilder.Entity("CodeFirstWebApplication.Entities.Prescription", b =>
                {
                    b.HasOne("CodeFirstWebApplication.Entities.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirstWebApplication.Entities.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeFirstWebApplication.Entities.Prescription_Medicament", b =>
                {
                    b.HasOne("CodeFirstWebApplication.Entities.Medicament", "Medicament")
                        .WithMany("Prescription_Medicament")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirstWebApplication.Entities.Prescription", "Prescription")
                        .WithMany("Prescription_Medicament")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}