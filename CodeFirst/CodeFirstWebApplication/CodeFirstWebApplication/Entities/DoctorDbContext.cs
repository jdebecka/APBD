using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApplication.Entities
{
    public class DoctorDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DoctorDbContext()
        {
            
        }

        public DoctorDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired();
            });
        }
    }
}