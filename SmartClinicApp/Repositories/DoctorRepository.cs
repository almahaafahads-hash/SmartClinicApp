using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        // تعريف قائمة الأطباء (خارج الدالات عشان تكون ثابتة)
        private static List<Doctor> _doctors = new List<Doctor>
        {
            new Doctor { Id = 1, Name = "د. خالد", Specialization = "باطنية" },
            new Doctor { Id = 2, Name = "د. هند", Specialization = "أطفال" }
        };

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctors;
        }

        public void AddDoctor(Doctor doctor)
        {
            // إعطاء رقم ID جديد تلقائي
            doctor.Id = _doctors.Max(d => d.Id) + 1;
            _doctors.Add(doctor);
        }
    }
}