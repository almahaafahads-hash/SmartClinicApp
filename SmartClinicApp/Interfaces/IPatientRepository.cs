using SmartClinicApp.Domain.Patients; // نربطه بمودل المريض اللي سويتيه

namespace SmartClinicApp.Interfaces
{
    public interface IPatientRepository
    {
        // تعريف الدالة اللي بتجيب كل المرضى (بدون كود تنفيذي)
        IEnumerable<Patient> GetAllPatients();
    }
}