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

        // ✅ يجيب طبيب واحد حسب الـ ID
        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }

        // ✅ تعديل طبيب
        public void UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        // ✅ حذف طبيب
        public void DeleteDoctor(int id)
        {
            var doctor = GetDoctorById(id);
            if (doctor == null) return;

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}