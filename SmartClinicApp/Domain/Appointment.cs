using System;
using System.Numerics;

namespace SmartClinicApp.Domain
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        // Foreign Keys
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        // Navigation Properties
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
    }
}