using SmartClinicApp.Domain;

namespace SmartClinicApp.Interfaces
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAllDoctors();
        // هذا السطر اللي يخلي الكنترولر يشوف دالة الإضافة
        void AddDoctor(Doctor doctor);
    }
}