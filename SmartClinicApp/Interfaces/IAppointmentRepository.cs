using SmartClinicApp.Domain;

namespace SmartClinicApp.Interfaces
{
    public interface IAppointmentRepository
    {
        // جلب كل المواعيد
        IEnumerable<Appointment> GetAllAppointments();

        // إضافة موعد جديد
        void AddAppointment(Appointment appointment);

        // التحقق هل الوقت متاح للدكتور
        bool IsDoctorAvailable(int doctorId, DateTime appointmentDate);
    }
}