using SmartClinicApp.Domain; // نربطه بمودل المريض اللي سويتيه

namespace SmartClinicApp.Interfaces
{
    public interface IPatientRepository
    {
        // تعريف أمر إضافة مريض جديد في النظام
        void AddPatient(Patient patient);
        // تعريف الدالة اللي بتجيب كل المرضى (بدون كود تنفيذي)
        IEnumerable<Patient> GetAllPatients();
  
    }

}