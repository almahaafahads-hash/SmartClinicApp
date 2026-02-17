using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartClinicApp.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private static List<Appointment> _appointments = new List<Appointment>();

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _appointments;
        }

        public bool IsDoctorAvailable(int doctorId, DateTime appointmentDate)
        {
            return !_appointments.Any(a =>
                a.DoctorId == doctorId &&
                a.AppointmentDate == appointmentDate
            );
        }

        public void AddAppointment(Appointment appointment)
        {
            if (!IsDoctorAvailable(appointment.DoctorId, appointment.AppointmentDate))
            {
                throw new Exception("عفواً، الدكتور لديه موعد آخر في هذا الوقت!");
            }

            appointment.Id = _appointments.Count > 0
                ? _appointments.Max(a => a.Id) + 1
                : 1;

            _appointments.Add(appointment);
        }
    }
}