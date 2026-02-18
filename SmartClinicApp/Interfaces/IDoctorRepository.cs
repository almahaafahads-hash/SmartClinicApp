using SmartClinicApp.Domain;

namespace SmartClinicApp.Interfaces
{
    public interface IDoctorRepository
    {
        // عرض كل الأطباء
        IEnumerable<Doctor> GetAllDoctors();

        // إضافة طبيب جديد
        void AddDoctor(Doctor doctor);

        // ✅ جلب طبيب بالـ ID (للتعديل/الحذف)
        Doctor GetDoctorById(int id);

        // ✅ تعديل بيانات طبيب
        void UpdateDoctor(Doctor doctor);

        // ✅ حذف طبيب
        void DeleteDoctor(int id);
    }
}