using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    // هنا نقول إن هذا الكلاس ينفذ وعود الـ IPatientRepository
    public class PatientRepository : IPatientRepository
    {
        public IEnumerable<Patient> GetAllPatients()
        {
            // نرجع قائمة وهمية حالياً حتى نربط الداتابيس

            return new List<Patient>
            {
                new Patient { Id = 1, FullName = "ريما محمد", MedicalHistory = "متابعة دورية" },
                new Patient { Id = 2, FullName = "سارة المنصور", MedicalHistory = "فحص عام" }
            };
        }
    }
}