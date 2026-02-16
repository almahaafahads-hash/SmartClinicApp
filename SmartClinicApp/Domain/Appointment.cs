namespace SmartClinicApp.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; } // رقم المريض المرتبط بالموعد
        public int DoctorId { get; set; }  // رقم الدكتور المرتبط بالموعد
        public DateTime AppointmentDate { get; set; } // تاريخ ووقت الموعد
        public string Notes { get; set; } // ملاحظات (اختياري)
    }
}