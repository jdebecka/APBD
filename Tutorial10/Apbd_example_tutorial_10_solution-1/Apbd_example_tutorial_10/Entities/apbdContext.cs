using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Apbd_example_tutorial_10.Entities
{
    public partial class apbdContext : DbContext
    {
        public apbdContext()
        {
        }

        public apbdContext(DbContextOptions<apbdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433\\Catalog=apbd;Database=apbd;User=sa;Password=Winter2019;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(x => x.IdEnrolment)
                    .HasName("enrollment_pk");

                entity.Property(e => e.IdEnrolment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(x => x.IdStudy)
                    .HasConstraintName("FK__Enrollmen__IdStu__267ABA7A");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => x.IndexNumber)
                    .HasName("student_pk");

                entity.ToTable("student");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(x => x.IdEnrollment)
                    .HasConstraintName("FK__student__IdEnrol__29572725");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(x => x.IdStudy)
                    .HasName("studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
