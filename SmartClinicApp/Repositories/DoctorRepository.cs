using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        // القائمة اللي تحفظ الأطباء
        private static List<Doctor> _doctors = new List<Doctor>();

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctors;
        }

        public void AddDoctor(Doctor doctor)
        {
            // إعطاء رقم تسلسلي للطبيب
            doctor.Id = _doctors.Count > 0 ? _doctors.Max(d => d.Id) + 1 : 1;
            _doctors.Add(doctor);
        }
    }
}