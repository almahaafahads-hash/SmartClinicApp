using SmartClinicApp.Domain;

namespace SmartClinicApp.Interfaces
{
    public interface IAppointmentRepository
    {
        // أمر لجلب كل المواعيد
        IEnumerable<Appointment> GetAllAppointments();

        // أمر لإضافة موعد جديد
        void AddAppointment(Appointment appointment);
    }
}