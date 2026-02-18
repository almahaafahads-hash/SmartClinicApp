using Microsoft.EntityFrameworkCore;
using SmartClinicApp.Data;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToList();
        }

        public bool IsDoctorAvailable(int doctorId, DateTime appointmentDate)
        {
            return !_context.Appointments.Any(a =>
                a.DoctorId == doctorId &&
                a.AppointmentDate == appointmentDate
            );
        }

        public void AddAppointment(Appointment appointment)
        {
            if (!IsDoctorAvailable(appointment.DoctorId, appointment.AppointmentDate))
                throw new Exception("عفواً، الدكتور لديه موعد آخر في هذا الوقت!");

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
    }
}