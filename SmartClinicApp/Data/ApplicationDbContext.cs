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

        // جداول قاعدة البيانات
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        // جدول المستخدمين (Register / Login)
        public DbSet<AppUser> AppUsers { get; set; }
    }
}