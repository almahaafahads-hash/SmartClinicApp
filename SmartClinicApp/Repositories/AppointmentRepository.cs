using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private static List<Appointment> _appointments = new List<Appointment>();

        public IEnumerable<Appointment> GetAllAppointments() => _appointments;

        public void AddAppointment(Appointment appointment)
        {
            // شرط ذكي: التأكد إن الدكتور ما عنده موعد بنفس الوقت
            var isBusy = _appointments.Any(a =>
                a.DoctorId == appointment.DoctorId &&
                a.AppointmentDate == appointment.AppointmentDate);

            if (isBusy)
            {
                throw new Exception("عفواً، الدكتور لديه موعد آخر في هذا الوقت!");
            }

            appointment.Id = _appointments.Count > 0 ? _appointments.Max(a => a.Id) + 1 : 1;
            _appointments.Add(appointment);
        }
    }
}