using SmartClinicApp.Domain;

namespace SmartClinicApp.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments();
        void AddAppointment(Appointment appointment);

        Appointment GetAppointmentById(int id);   // جديد
        void UpdateAppointment(Appointment appointment); // جديد
        void DeleteAppointment(int id); // جديد
    }
}