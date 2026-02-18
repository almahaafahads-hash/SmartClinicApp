using Microsoft.EntityFrameworkCore;
using SmartClinicApp.Domain;

namespace SmartClinicApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ----------- Tables ----------
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        // ----------- Relationships ----------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================= Doctor =================
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.Id);   // Primary Key
                entity.Property(d => d.Name).IsRequired();
            });

            // ================= Patient =================
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.Id);   // Primary Key
                entity.Property(p => p.FullName).IsRequired();
            });

            // ================= Appointment =================
            modelBuilder.Entity<Appointment>(entity =>
            {
                // Primary Key
                entity.HasKey(a => a.Id);

                // Doctor -> Appointment (One to Many)
                entity.HasOne(a => a.Doctor)
                      .WithMany()
                      .HasForeignKey(a => a.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Patient -> Appointment (One to Many)
                entity.HasOne(a => a.Patient)
                      .WithMany()
                      .HasForeignKey(a => a.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}