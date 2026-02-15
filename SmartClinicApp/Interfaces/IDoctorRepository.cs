using SmartClinicApp.Domain; // استدعاء مودل الدكتور

namespace SmartClinicApp.Interfaces
{
    public interface IDoctorRepository
    {
        // هذه الدالة هي "العقد" اللي يضمن لنا استرجاع قائمة الأطباء
        IEnumerable<Doctor> GetAllDoctors();
    }
}