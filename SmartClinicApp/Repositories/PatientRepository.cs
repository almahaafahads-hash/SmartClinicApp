using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        // 1. تعريف القائمة (المخزن)
        private static List<Patient> _patients = new List<Patient>
        {
            new Patient { Id = 1, FullName = "ريما محمد", MedicalHistory = "مستقر" },
            new Patient { Id = 2, FullName = "سارة المنصور", MedicalHistory = "مراجعة" }
        };

        // 2. دالة عرض المرضى
        public IEnumerable<Patient> GetAllPatients()
        {
            return _patients;
        }

        // 3. دالة إضافة مريض جديد
        public void AddPatient(Patient patient)
        {
            // نعطي رقم جديد بناءً على آخر رقم موجود
            patient.Id = _patients.Max(p => p.Id) + 1;

            // نضيف المريض للقائمة
            _patients.Add(patient);
        }
    } // هذا قوس قفلة الكلاس (الأساسي)
} // هذا قوس قفلة النيم-سبيس (المجلد)