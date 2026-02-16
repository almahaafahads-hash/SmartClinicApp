using SmartClinicApp.Data;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        // نربط المستودع بقاعدة البيانات
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // يجيب كل الأطباء من الـ SQL
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        // يضيف طبيب جديد في الـ SQL
        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
    }
}