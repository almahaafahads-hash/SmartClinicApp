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
                .OrderByDescending(a => a.AppointmentDate)
                .ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefault(a => a.Id == id);
        }

        public void AddAppointment(Appointment appointment)
        {
            var isBusy = _context.Appointments.Any(a =>
                a.DoctorId == appointment.DoctorId &&
                a.AppointmentDate == appointment.AppointmentDate);

            if (isBusy)
                throw new Exception("عفواً، الدكتور لديه موعد آخر في هذا الوقت!");

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            var appt = _context.Appointments.FirstOrDefault(a => a.Id == id);
            if (appt == null) return;

            _context.Appointments.Remove(appt);
            _context.SaveChanges();
        }
    }
}